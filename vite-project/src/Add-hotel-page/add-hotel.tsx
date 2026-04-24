import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

interface ProductFormData {
  name: string;
  price: number;
  country: string;
  city: string;
  description: string;
  categoryId: number;
  createDateFrom: string;
  createDateTo: string;
  tags: number[];
  images: File[];
  previewImageIndex: number;
}

export default function AddHotel() {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const [formData, setFormData] = useState<ProductFormData>({
    name: '',
    price: 0,
    country: '',
    city: '',
    description: '',
    categoryId: 1, 
    createDateFrom: '',
    createDateTo: '',
    tags: [1], 
    images: [],
    previewImageIndex: 0,
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: name === 'price' || name === 'categoryId' ? Number(value) : value,
    }));
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setFormData(prev => ({
        ...prev,
        images: Array.from(e.target.files!)
      }));
    }
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setError(null);
    setLoading(true);


    const tokenDataRaw = localStorage.getItem('token');
    if (!tokenDataRaw) {
      setError("Ви не авторизовані. Будь ласка, увійдіть в систему.");
      setLoading(false);
      return;
    }

    let cleanToken = "";
    try {

      const parsedData = JSON.parse(tokenDataRaw);
      cleanToken = parsedData.payLoad || tokenDataRaw; 
    } catch {
      cleanToken = tokenDataRaw;
    }

    try {
      const data = new FormData();


      data.append('Name', formData.name);
      data.append('Price', formData.price.toString());
      data.append('Country', formData.country);
      data.append('City', formData.city);
      data.append('Description', formData.description);
      data.append('CategoryId', formData.categoryId.toString());
      data.append('CreateDateFrom', formData.createDateFrom);
      data.append('CreateDateTo', formData.createDateTo);
      
 
      data.append('PreviewImageId', formData.previewImageIndex.toString());


      formData.tags.forEach(tag => data.append('Tags', tag.toString()));

      formData.images.forEach((file) => {
        data.append('Images', file);
      });

      const response = await fetch('https://localhost:7147/api/products/from-form', {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${cleanToken}`
        },
        body: data,
      });

      if (response.status === 401) throw new Error("Помилка: Неавторизовано (401)");
      if (response.status === 403) throw new Error("Доступ заборонено: Ви не рієлтор (403)");

      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(errorText || "Помилка сервера");
      }

      alert("Готель успішно додано!");
      navigate('/dashboard'); // Або інша сторінка

    } catch (err: any) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '600px', margin: '20px auto', padding: '20px', border: '1px solid #ddd', borderRadius: '8px' }}>
      <h2>Додати новий готель</h2>
      <form onSubmit={handleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
        
        <input name="name" placeholder="Назва готелю" onChange={handleChange} required />
        <input name="price" type="number" placeholder="Ціна за ніч" onChange={handleChange} required />
        
        <div style={{ display: 'flex', gap: '10px' }}>
          <input name="country" placeholder="Країна" onChange={handleChange} required style={{ flex: 1 }} />
          <input name="city" placeholder="Місто" onChange={handleChange} required style={{ flex: 1 }} />
        </div>

        <textarea name="description" placeholder="Детальний опис" onChange={handleChange} required style={{ height: '100px' }} />

        <div style={{ display: 'flex', gap: '10px' }}>
          <div style={{ flex: 1 }}>
            <label>Дата з:</label>
            <input name="createDateFrom" type="date" onChange={handleChange} style={{ width: '100%' }} />
          </div>
          <div style={{ flex: 1 }}>
            <label>Дата до:</label>
            <input name="createDateTo" type="date" onChange={handleChange} style={{ width: '100%' }} />
          </div>
        </div>

        <div>
          <label>Фотографії:</label>
          <input type="file" multiple onChange={handleFileChange} accept="image/*" style={{ display: 'block', marginTop: '5px' }} />
        </div>

        {/* Секція вибору прев'ю */}
        {formData.images.length > 0 && (
          <div style={{ background: '#f9f9f9', padding: '10px', borderRadius: '5px' }}>
            <p style={{ fontSize: '14px', margin: '0 0 10px 0' }}>Оберіть головне фото:</p>
            <div style={{ display: 'flex', gap: '10px', flexWrap: 'wrap' }}>
              {formData.images.map((file, index) => (
                <div 
                  key={index} 
                  onClick={() => setFormData(p => ({ ...p, previewImageIndex: index }))}
                  style={{
                    width: '70px', height: '70px', borderRadius: '4px', overflow: 'hidden',
                    border: formData.previewImageIndex === index ? '3px solid #007bff' : '1px solid #ccc',
                    cursor: 'pointer', position: 'relative'
                  }}
                >
                  <img src={URL.createObjectURL(file)} alt="" style={{ width: '100%', height: '100%', objectFit: 'cover' }} />
                </div>
              ))}
            </div>
          </div>
        )}

        {error && <div style={{ color: 'red', fontSize: '14px', padding: '10px', background: '#fff5f5' }}>{error}</div>}

        <button 
          type="submit" 
          disabled={loading}
          style={{
            padding: '12px', background: '#007bff', color: 'white', border: 'none', 
            borderRadius: '5px', cursor: loading ? 'not-allowed' : 'pointer'
          }}
        >
          {loading ? 'Надсилання...' : 'Зберегти готель'}
        </button>
      </form>
    </div>
  );
}