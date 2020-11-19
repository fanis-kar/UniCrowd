using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetGroups();

        Group GetGroup(int groupId);

        void AddGroup(Group group);

        System.Threading.Tasks.Task UpdateGroupAsync(Group group);
    }
}
