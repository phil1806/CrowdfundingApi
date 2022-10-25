using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ExtModels {
    public static class StatusBllExt {

        public static bool Comparre(this StatusBll s1, StatusBll s2) {
            return s1.Id == s2.Id && s1.TypeStatus == s2.TypeStatus;
        }

    }
}
