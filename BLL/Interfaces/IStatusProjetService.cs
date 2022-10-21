using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {
    public interface IStatusProjetService {

        public void Create(StatusBll s);
        public void Delete(int i);
        public void Update(StatusBll s);
        public IEnumerable<StatusBll> GetAll();

    }
}
