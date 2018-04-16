using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.Utilities.Message
{
    public class CommonClientMessage
    {
        public static readonly string UnexpectedException = "Không thể tiếp tục ván chơi. Mời rời phòng";
        public static readonly string NotEnoughMoneyToContinue = "Bạn không đủ tiền để tiếp tục ván chơi.";
        public static readonly string NoUserAction = "Bạn đã không có hành động trong vòng 15 phút.";
        public static readonly string BillingError = "Giao dịch không thành công, tài khoản sẽ được hoàn tiền.";


        public static readonly string UserRegLeaveRoom = "Đăng ký rời phòng.";
        public static readonly string OtherRegLeaveRoom = "Người chơi đăng ký rời phòng.";

        public static readonly string OtherDisconnected = "Người chơi mất kết nối.";
        public static readonly string UserDisconnected = "Bạn bị mất kết nối.";

        
        public static string NotEnoughMoney(long amount, byte type)
        {
            return string.Format("Bạn cần ít nhất {0} {1} để tiếp tục ván chơi. Bạn có muốn nạp thêm {1} để chơi (nạp từ VCOIN, Thẻ cào...)?", amount, type == 0 ? "Xu" : "Sao");
        }

        public static string NoActionDuring(int minute)
        {
            return string.Format("Bạn đã không có hành động trong vòng {0} phút.", minute);
        }
    }
}
