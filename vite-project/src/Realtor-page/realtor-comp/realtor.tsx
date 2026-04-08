import './realtor.scss';
function Realtor() {
  return (
    <div className='realtor-container'>
      <div className='realtor-block'>
        {/* Ліва частина */}
        <div className='realtor-main-content'>
          <div className='realtor-header'>
            <h1 className='realtor-full-name'>Дмитро Романчук <span className='rating'>★ 9.7</span></h1>
            <p className='realtor-email'>dmytro937@gmail.com</p>
          </div>

          <div className='realtor-data'>
            <div className='data-item'>
              <p className='label'>Номер телефону</p>
              <div className='input-box'>+380998776543</div>
            </div>
            <div className='data-item'>
              <p className='label'>Дата народження</p>
              <div className='input-box'>17.09.1973</div>
            </div>
            <div className='data-item'>
              <p className='label'>Стать</p>
              <div className='input-box'>Чоловік</div>
            </div>
          </div>

          <div className='realtor-description'>
            <h2 className='description-title'>Інформація про рієлтора</h2>
            <p className='description-text'>
              З багаторічним досвідом у сфері нерухомості, я пропоную широкий вибір комфортних апартаментів та 
              будинків у найкращих локаціях. Незалежно від того, чи шукаєте ви житло для відпочинку на узбережжі, чи 
              просторі апартаменти для тривалого проживання в центрі міста, я допоможу підібрати найкращий варіант, 
              що відповідає вашим потребам і бюджету.
            </p>
          </div>
        </div>

        {/* Права частина */}
        <div className='realtor-aside'>
          <div className='photo-container'>
            <img className='realtor-photo' src='/src/assets/realtor.jpg' alt='Рієлтор' />
          </div>
          <button className='feedback-button'>Написати відгук</button>
        </div>
      </div>
    </div>
  );
}

export default Realtor;