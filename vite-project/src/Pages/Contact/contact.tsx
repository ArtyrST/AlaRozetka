import './contact.scss';
import { useEffect , useState, useRef } from 'react';

export interface FAQItem {
    question: string;
    answer: string;
}

// faqData.ts
export const faqData: FAQItem[] = [
    {
        question: "Як я можу оплатити бронь апартаментів?",
        answer: "Ми приймаємо різні види оплати: готівкою в головному офісі, банківською карткою на сайті, через термінали самообслуговування та електронні гаманці."
    },
    {
        question: "Чи можливо отримати більше інформації про вибраний готель?",
        answer: "Звісно, ви можете зателефонувати в наш офіс і вам нададуть повну інформацію про вибрані вами апартаменти чи готель."
    },
    {
        question: "Чи можу я відмінити бронь?",
        answer: "Так, протягом 24 годин у вас є можливість відмовитись від апартаментів і ми зможемо запропонувати вам інший варіант."
    }
];



function ContactPage() {
// Стан для FAQ: зберігаємо індекс відкритого питання (або null, якщо все закрито)
    const [activeIndex, setActiveIndex] = useState<number | null>(null);
    
    // Референс для контейнера, щоб знайти всі секції для анімації
    const containerRef = useRef<HTMLDivElement>(null);

    // 1. Логіка анімації появи (Intersection Observer)
    useEffect(() => {
        const observer = new IntersectionObserver(
            (entries) => {
                entries.forEach((entry) => {
                    if (entry.isIntersecting) {
                        entry.target.classList.add('visible');
                    }
                });
            },
            { threshold: 0.1 }
        );

        const sections = document.querySelectorAll('.contact-section');
        sections.forEach((section) => observer.observe(section));

        return () => observer.disconnect();
    }, []);

    // 2. Функція для перемикання FAQ
    const toggleFAQ = (index: number) => {
        setActiveIndex(activeIndex === index ? null : index);
    };

    // 3. Обробка відправки форми
    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const formData = new FormData(e.currentTarget);
        console.log("Дані форми:", Object.fromEntries(formData));
        alert("Повідомлення надіслано!");
    };

    return (
    
        <div className="contact-container">
             
               
                    <section id="faq" className="contact-section visible">
                    <h2>Часті питання</h2>
                    <p className="section-subtitle">Знайдіть відповіді на найпоширеніші запитання.</p>
                    
                    <div className="faq-container">
                        {faqData.map((item, index) => (
                        <div key={index} className="faq-item">
                            <div 
                            className="faq-question" 
                            onClick={() => toggleFAQ(index)}
                            role="button"
                            tabIndex={0}
                            >
                            <h3>{item.question}</h3>
                            <span className="faq-toggle">
                                {activeIndex === index ? '−' : '+'}
                            </span>
                            </div>
                            
                            <div className={`faq-answer ${activeIndex === index ? 'active' : ''}`}>
                            <p>{item.answer}</p>
                            </div>
                        </div>
                        ))}
                    </div>
                    </section>

                    <section id="contacts" className="contact-section">
                        <h2>Наші контакти</h2>
                        
                        <div className="contacts-container">
                            <div className="contact-info">
                                <h3>Контактна інформація</h3>
                                <div className="contact-details">
                                    <p><strong>Адреса:</strong> м. Львів, вул. Золота 34</p>
                                    <p><strong>Телефон:</strong> +380 (68) 766-03-47</p>
                                    <p><strong>Email:</strong> danylo2879@gmail.com</p>
                                    <p>
                                    <strong>Графік роботи:</strong><br />
                                    Пн-Пт: 9.00 - 20.00<br />
                                    Сб-Нд: 10.00 - 18.00
                                    </p>
                                </div>
                                
                                
                                <div className="social-media">
                                    <h3>Ми в соцмережах</h3>
                                    <div className="social-icons">
                                        <a href="https://www.facebook.com/profile.php?id=100042500617631" className="social-icon">FB</a>
                                        <a href="https://www.youtube.com/channel/UCjh3EprYP41HFvOxJWORL7w" className="social-icon">IY</a>
                                        <a href="https://www.instagram.com/danylo_tomash/?next=%2F" className="social-icon">TW</a>
                                    </div>
                                </div>
                            </div>
                            
                            <div className="contact-form">
                                <h3>Напишіть нам</h3>
                                <p>Маєте запитання чи пропозицію? Заповніть форму, і ми зв'яжемося з вами!</p>
                                
                                <form id="contactForm">
                                    <div className="form-group">
                                        <label >Ваше ім'я</label>
                                        <input type="text" id="name" placeholder="Введіть ваше ім'я" required></input>
                                    </div>
                                    
                                    <div className="form-group">
                                        <label >Ваш email</label>
                                        <input type="email" id="email" placeholder="Введіть ваш email" required></input>
                                    </div>
                                    
                                    <div className="form-group">
                                        <label >Тема звернення</label>
                                        <input type="text" id="subject" placeholder="Оберіть тему..."></input>
                                    </div>
                                    
                                    <div className="form-group">
                                        <label >Ваше повідомлення</label>
                                        <textarea id="message" placeholder="Напишіть щось..." required></textarea>
                                    </div>
                                    
                                    <button type="submit" className="submit-btn">Надіслати</button>
                                </form>
                            </div>
                        </div>
                    </section>

                    <section  className="contact-section">
                        <h2>Ми на карті</h2>
                        <p className="section-subtitle">Ми знаходимося в самому центрі Львова</p>
                        
                        <div className="map-container">
                        <div id="map" className="map-container"></div>
                        </div>
                        
                        
                    </section>
               
        </div>
    );
}
export default ContactPage;