using System.Collections.Generic;
using System.Threading.Tasks;
using Tehk.Orgs.Models;

namespace Tehk.Orgs.Svc.Services
{
    public interface IOrgService
    {
        Task<IEnumerable<OrgModel>> List();

        Task<OrgModel> Find(string slug);

        Task<OrgModel> Update(string slug, OrgModel org);

        Task<OrgModel> Delete(string slug);
    }
}