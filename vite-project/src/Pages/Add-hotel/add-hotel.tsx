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

  return (
    <div className="gh-container">
      <div className="gh-card">
        <h2 className="gh-title">Інформація про кімнату</h2>
        
        <form className="gh-form">
          {/* 1. Період оренди */}
          <div className="gh-section">
            <div className="gh-num">1</div>
            <div className="gh-content">
              <label className="gh-label">Доступний період оренди</label>
              <div className="gh-grid">
                <input type="date" name="createDateFrom" className="gh-input" onChange={handleChange} />
                <input type="date" name="createDateTo" className="gh-input" onChange={handleChange} />
              </div>
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
                  <option value={2}>Хостел</option>
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

          <button type="submit" className="gh-submit">Добавити</button>
        </form>
      </div>
    </div>
  );
}