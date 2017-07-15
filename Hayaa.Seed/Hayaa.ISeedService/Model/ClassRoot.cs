using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
   public class ClassRoot
    {
        /// <summary>
        /// 展示标题
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 数据说明
        /// </summary>
        public string Description { set; get; }
        public int CreateBy { set; get; }
        public DateTime CreateTime { set;get; }
        public int ModifyBy { set; get; }
        public DateTime ModifyTime { set; get; }
        public int DeleteBy { set; get; }
        public DateTime? DeleteTime { set; get; }
        private bool _IsDelete = false;
        public bool IsDelete {
            set
            {
                _IsDelete = value;
            }
            get
            {
                return _IsDelete;
            }
        }

    }
}
