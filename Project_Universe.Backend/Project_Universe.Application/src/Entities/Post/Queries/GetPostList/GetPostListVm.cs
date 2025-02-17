using Project_Universe.Application.src.Entities.Staff.Queries.GetStaffList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Entities.Post.Queries.GetPostList
{
    public class GetPostListVm
    {
        public IList<GetPostLookupDto> Post { get; set; }
    }
}
