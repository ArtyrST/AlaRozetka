import type { Hotel } from './types/hotel.types';

const API_URL = 'http://localhost:5164';

export const hotelService = {
  async getAll(): Promise<Hotel[]> {
    const response = await fetch(`${API_URL}/api/products`);

    if (!response.ok) {
      throw new Error('Не вдалося отримати готелі');
    }

    const data = await response.json();

    if (!data || !Array.isArray(data.payLoad)) {
      return [];
    }

    return data.payLoad.map((hotel: any) => {
      // Логіка обробки шляху до картинки
      const rawPath = hotel.images?.find((img: any) => img.isPreview)?.path 
        || hotel.images?.[0]?.path;

      let fullPath = 'https://via.placeholder.com/400x250?text=No+Image';

      if (rawPath) {
        // Виправляємо регістр папок (Uploads/Images)
        const correctedPath = rawPath
          .replace('/uploads/', '/Uploads/')
          .replace('/images/', '/Images/');
        
        fullPath = `${API_URL}${correctedPath.startsWith('/') ? '' : '/'}${correctedPath}`;
      }

      return {
        ...hotel,
        location: `${hotel.city}, ${hotel.country}`,
        displayImage: fullPath,
        oldPrice: Math.round(hotel.price * 1.15),
        rating: 8.5, // Тимчасовий хардкод
        formattedDateFrom: new Date(hotel.dateFrom).toLocaleDateString('uk-UA'),
        formattedDateTo: new Date(hotel.dateTo).toLocaleDateString('uk-UA'),
      };
    });
  }
};