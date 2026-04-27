import Realtor from './realtor-comp/realtor';
import RealtorHotels from './realtor-hotels/realtor-hotels';
import RealtorReviews from './realtor-reviews/realtor-reviews';
export const RealtorPage = () => {
  return (
    <div className="layout">
      <Realtor />    
      <RealtorHotels />     
      <RealtorReviews />
    </div>
  );
};
