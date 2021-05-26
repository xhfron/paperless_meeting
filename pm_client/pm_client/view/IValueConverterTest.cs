using pm_client.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pm_client.view {
    class AnonymousConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if ((int)value == 0) {
                return "实名投票";
            } else {
                return "匿名投票";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return 0;
        }
    }
    class VoteStateConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if ((int)value == Vote.VOTING) {
                return "进行中";
            } else if((int)value==Vote.VOTED){
                return "已结束";
            } else if((int)value==Vote.IDLE){
                return "未开始";
            } else {
                return "这是个锤子状态";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return 0;
        }
    }
}
