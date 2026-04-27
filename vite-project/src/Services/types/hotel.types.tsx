export type ImageDto = {
  id: number;
  path: string;
  isPreview: boolean;
};

export interface Hotel {
  id: number;
  name: string;
  price: number;
  country: string;
  city: string;
  description: string;
  categoryId: number;
  categoryName: string;
  tags: number[];
  images: ImageDto[];
  dateFrom: string;
  dateTo: string;
  userId: number;
  // Допоміжні поля для UI
  location: string;
  displayImage: string;
  oldPrice: number;
  rating: number;
  formattedDateFrom?: string;
  formattedDateTo?: string;
}