//Christopher Sanderson
//Friends
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Models
{
    public interface IFriendsRepository
    {
        IQueryable<Friend> allFriends { get; }

        void SaveFriend(Friend friends);


        Friend deleteFriends(int ID);
    }
}
