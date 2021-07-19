using ClaimDeptPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepRepository
{
    public class ClaimDepRepo
    {
        //Fields
        public List<Claim> listOfAllClaimData = new List<Claim>();
        public Queue<Claim> queueOfAllClaimData = new Queue<Claim>();
        //Create
        public void AddToListOfAllClaimData(Claim claimData)
        {
            listOfAllClaimData.Add(claimData);
        }
        public void AddToQueueOfAllClaimData(Claim claimData)
        {
            queueOfAllClaimData.Enqueue(claimData);
        }
        //Read
        public List<Claim> GetAllListClaimData()
        {
            return listOfAllClaimData;
        }

        public Queue<Claim> GetQueueClaimData()
        {
            return queueOfAllClaimData;
        }
        //Delete DeQueue???

        public void RemoveClaimFromList()
        {
            Claim claimToBeRemoved = queueOfAllClaimData.Peek();
            listOfAllClaimData.Remove(claimToBeRemoved);            
        }

        public void TakeNextClaimInQueue()
        {
            queueOfAllClaimData.Peek();
        }
        //Helper
        private Claim GetClaimByClaimId(int claimData)
        {
            foreach (Claim claimIdNumber in listOfAllClaimData)
            {
                if (claimData == claimIdNumber.ClaimId)
                {
                    return claimIdNumber;
                }
            }
            return null;
        }
    }
}
