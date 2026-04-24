

function RealtorFullInfo(){
    return(
        <div>
        <h1 className="page-title">Особисті дані</h1>
        
        <div className="header-info">
          <h2>Дмитро Романчук</h2>
          <p>dmytro937@gmail.com</p>
        </div>

        <form className="personal-data-form">
          <div className="form-group">
            <label>Опис</label>
            <div className="textarea-wrapper">
              <textarea 
                defaultValue="З багаторічним досвідом у сфері нерухомості, я пропоную широкий вибір комфортних апартаментів та будинків у найкращих локаціях. Незалежно від того, чи шукаєте ви житло для відпочинку на узбережжі, чи просторі апартаменти для тривалого проживання в центрі міста, я допоможу підібрати найкращий варіант, що відповідає вашим потребам і бюджету."
                readOnly
              />
              <span className="char-count">0/4000</span>
            </div>
          </div>

          <div className="form-group">
            <label>Номер телефону</label>
            <input type="text" defaultValue="+380998776543" readOnly />
          </div>

          <div className="form-group">
            <label>Дата народження</label>
            <input type="text" defaultValue="17.09.1973" readOnly />
          </div>

          <div className="form-group">
            <label>Громадянство</label>
            <input type="text" defaultValue="Українець" readOnly />
          </div>

          <div className="form-group">
            <label>Стать</label>
            <input type="text" defaultValue="Чоловік" readOnly />
          </div>

          <div className="form-group">
            <label>Адреса</label>
            <input type="text" defaultValue="Кравчука 45А" readOnly />
          </div>

          {/* Нижній ряд з випадаючими списками та кнопкою */}
          <div className="form-row bottom-row">
            <div className="form-group half-width">
              <label>Країна</label>
              <select disabled>
                <option>Україна</option>
              </select>
            </div>

            <div className="form-group half-width">
              <label>Місто</label>
              <select disabled>
                <option>Луцьк</option>
              </select>
            </div>

            <div className="button-group">
              <button type="button" className="edit-btn">Редагувати</button>
            </div>
          </div>
        </form>

       </div>
    );
}
export default RealtorFullInfo;