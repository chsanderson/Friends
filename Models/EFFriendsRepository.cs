//Christopher Sanderson
//Friends
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Models
{
    public class EFFriendsRepository : IFriendsRepository
    {
        private ApplicationDbContext context;

        public EFFriendsRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Friend> allFriends => context.friends;

        //this allows friends records to be created or updated and saves these changes to the database
        public void SaveFriend(Friend friends)
        {
            if(friends.ID == 0)
            {
                context.friends.Add(friends);
            }
            else
            {
                Friend record = context.friends.FirstOrDefault(r => r.ID == friends.ID);
                if(record != null)
                {
                    record.FirstName = friends.FirstName;
                    record.LastName = friends.LastName;
                }
            }
                context.SaveChanges();
        }

        //this allows friends records to be deleted from the database and the changes to be saved to the database
        public Friend deleteFriends(int ID)
        {
            Friend records = context.friends.FirstOrDefault(r => r.ID == ID);

            if(records != null)
            {
                context.friends.Remove(records);
                context.SaveChanges();
            }
            return records;
        }
    }
}
