using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus_Poll_CS
{
    public class BoardsModel
    {
        public int ID { get; set; }
        public int SerialNumber { get; set; }
        public long SlaveID { get; set; }

        //public int v_Hardware { get; set; }
        //public int v_Software { get; set; }
        //public string Project { get; set; }

        //public string FullBoardInfo
        //{
        // get
        // {
        //        return $"{ SerialNumber } { v_Hardware } { v_Software } { Project }";
        // }

        //}
    }
}
