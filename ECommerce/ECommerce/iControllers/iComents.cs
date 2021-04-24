using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.iControllers
{
    public interface iComents
    {
        ComentsModel addComment(ComentsModel review);
        public List<ComentsModel> GetComment(int id);
        void UpdateComment(ComentsModel review);
        void DeleteComment(ComentsModel review);
        public ComentsModel GetCommentID(int id);
    }
}
