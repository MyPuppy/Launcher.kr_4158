using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using KartRider;

namespace RiderData
{
    public static class FavoriteItem
    {
        public static void Favorite_Item()
        {
            int itemCount = 16;
            using (OutPacket outPacket = new OutPacket("PrFavoriteItemGet"))
            {
                if (Program.FavoriteItem)
                {
                    outPacket.WriteInt(itemCount);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(839);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(854);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(872);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(905);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(935);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(937);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(955);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1007);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1017);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1031);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1034);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1044);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1045);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1074);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1078);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);

                    outPacket.WriteShort(3);
                    outPacket.WriteShort(1098);
                    outPacket.WriteShort(1);
                    outPacket.WriteByte(0);
                }
                else
                {
                    outPacket.WriteInt(0);
                }
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
    }
}