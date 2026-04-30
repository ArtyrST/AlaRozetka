import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './add-hotel.scss';

const AMENITIES = [
  { id: 1, label: 'Письмовий стіл та стілець' },
  { id: 2, label: 'Шафа або гардероб' },
  { id: 3, label: 'Бар' },
  { id: 4, label: 'Телевізор' },
  { id: 5, label: 'Телефон' },
  { id: 6, label: 'Кондиціонер' },
  { id: 7, label: 'Сейф' },
  { id: 8, label: 'Фен для волосся' },
  { id: 9, label: 'Зубна щітка та паста' },
  { id: 10, label: 'Рушники' }
];

export default function AddHotel() {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);


  const [formData, setFormData] = useState({
    name: '',
    price: 0,
    country: '',
    city: '',
    description: '',
    categoryId: 1,
    createDateFrom: '',
    createDateTo: '',
    tags: [] as number[],
    images: [] as File[],
    previewImageIndex: 0,
  });
 
  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: name === 'price' || name === 'categoryId' ? Number(value) : value,
    }));
  };

  const handleTagChange = (tagId: number) => {
    setFormData(prev => ({
      ...prev,
      tags: prev.tags.includes(tagId) ? prev.tags.filter(id => id !== tagId) : [...prev.tags, tagId]
    }));
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setFormData(prev => ({ ...prev, images: [...prev.images, ...Array.from(e.target.files!)] }));
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
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
        formData.images.forEach((file) => data.append('Images', file));

        const response = await fetch('https://localhost:7147/api/products/from-form', {
          method: 'POST',
          headers: {
            'Authorization': `Bearer ${cleanToken}`
          },
          body: data,
        });

        if (!response.ok) {
          const errorText = await response.text();
          throw new Error(errorText || "Помилка сервера");
        }

        alert("Готель успішно додано!");
        navigate('/Catalog');

      } catch (err: any) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };



  return (
    <div className="gh-container">
      <div className="gh-card">
      <h2 className="gh-title">Інформація про кімнату</h2>
      
      {error && <div style={{ color: 'red', marginBottom: '15px', padding: '10px', backgroundColor: '#ffe6e6', borderRadius: '5px' }}>{error}</div>}
      
      <form className="gh-form" onSubmit={handleSubmit}>
          {/* 1. Період оренди */}
          <div className="gh-section">
          <div className="gh-num">1</div>
          <div className="gh-content">
            <label className="gh-label">Доступний період оренди та Вартість</label>
            <div className="gh-grid">
              <input type="date" name="createDateFrom" className="gh-input" onChange={handleChange} required />
              <input type="date" name="createDateTo" className="gh-input" onChange={handleChange} required />
            </div>
            {/* ДОДАНО ПОЛЕ ДЛЯ ЦІНИ */}
            <input 
              type="number" 
              name="price" 
              className="gh-input gh-mt" 
              placeholder="Вартість за добу (грн)" 
              onChange={handleChange} 
              required 
            />
          </div>
        </div>

          {/* 2. Назва */}
          <div className="gh-section">
            <div className="gh-num">2</div>
            <div className="gh-content">
              <label className="gh-label">Назва номеру</label>
              <input type="text" name="name" className="gh-input gh-full" placeholder="Наприклад: Double Luxury Room" onChange={handleChange} />
            </div>
          </div>

          {/* 3. Тип та локація */}
          <div className="gh-section">
            <div className="gh-num">3</div>
            <div className="gh-content">
              <label className="gh-label">Тип номеру та локація</label>
              <div className="gh-grid">
                <select name="categoryId" className="gh-input gh-select" onChange={handleChange}>
                  <option value={1}>Готель</option>
                  <option value={2}>Апартаменти</option>
                  <option value={3}>Хостел</option>
                  <option value={4}>Вілли</option>
                  <option value={5}>Глемпінги</option>
                </select>
                <input type="text" name="country" className="gh-input" placeholder="Країна" onChange={handleChange} />
              </div>
              <input type="text" name="city" className="gh-input gh-full gh-mt" placeholder="Місто" onChange={handleChange} />
            </div>
          </div>

          {/* 4. Опис */}
          <div className="gh-section">
            <div className="gh-num">4</div>
            <div className="gh-content">
              <label className="gh-label">Опис</label>
              <textarea name="description" className="gh-input gh-textarea" placeholder="Опишіть номер..." onChange={handleChange} />
            </div>
          </div>

          {/* 5. Зручності */}
          <div className="gh-section">
            <div className="gh-num">5</div>
            <div className="gh-content">
              <label className="gh-label">Чим гості можуть користуватися у кімнаті?</label>
              <div className="gh-tags-box">
                {AMENITIES.map(tag => (
                  <label key={tag.id} className="gh-tag-item">
                    <input type="checkbox" checked={formData.tags.includes(tag.id)} onChange={() => handleTagChange(tag.id)} />
                    <span>{tag.label}</span>
                  </label>
                ))}
              </div>
            </div>
          </div>

          {/* 6. Фото */}
          <div className="gh-section">
            <div className="gh-num">6</div>
            <div className="gh-content">
              <label className="gh-label">Фотографії</label>
              <div className="gh-upload">
                <input type="file" multiple id="gh-file" onChange={handleFileChange} hidden />
                <label htmlFor="gh-file" className="gh-upload-btn">+ Додати фото</label>
              </div>
              <div className="gh-previews">
                {formData.images.map((img, i) => (
                  <div key={i} className={`gh-img-card ${formData.previewImageIndex === i ? 'active' : ''}`} onClick={() => setFormData(p => ({...p, previewImageIndex: i}))}>
                    <img src={URL.createObjectURL(img)} alt="" />
                  </div>
                ))}
              </div>
            </div>
          </div>

          <div className="gh-footer">
            <button type="submit" className="gh-submit" disabled={loading}>
              {loading ? 'Надсилання...' : 'Добавити'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}