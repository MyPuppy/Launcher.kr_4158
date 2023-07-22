using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using KartRider;

namespace RiderData
{
    public static class Emblem
    {
        public static void RmOwnerEmblemPacket()
        {
            using (OutPacket outPacket = new OutPacket("RmOwnerEmblemPacket"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteInt(1);
                int Emblem = 302;
                outPacket.WriteInt(Emblem - 101);
                for (short i = 8193; i <= 8494; i++)
                {
                    if (i == 8201 || i == 8232 || i == 8235 || i == 8261 || i == 8265 || i == 8271 || i == 8272 || i == 8279 || i == 8280 || i == 8283 ||
                        i == 8284 || i == 8292 || i == 8294 || i == 8303 || i == 8304 || i == 8308 || i == 8315 || i == 8316 || i == 8317 || i == 8318 ||
                        i == 8319 || i == 8320 || i == 8321 || i == 8322 || i == 8323 || i == 8324 || i == 8325 || i == 8326 || i == 8327 || i == 8328 ||
                        i == 8329 || i == 8330 || i == 8331 || i == 8332 || i == 8333 || i == 8334 || i == 8335 || i == 8336 || i == 8337 || i == 8339 ||
                        i == 8340 || i == 8341 || i == 8342 || i == 8343 || i == 8348 || i == 8349 || i == 8350 || i == 8351 || i == 8352 || i == 8353 ||
                        i == 8354 || i == 8355 || i == 8356 || i == 8357 || i == 8358 || i == 8359 || i == 8360 || i == 8369 || i == 8370 || i == 8375 ||
                        i == 8383 || i == 8384 || i == 8385 || i == 8392 || i == 8394 || i == 8395 || i == 8404 || i == 8407 || i == 8409 || i == 8410 ||
                        i == 8411 || i == 8412 || i == 8413 || i == 8415 || i == 8418 || i == 8421 || i == 8425 || i == 8426 || i == 8430 || i == 8435 ||
                        i == 8436 || i == 8437 || i == 8442 || i == 8443 || i == 8448 || i == 8451 || i == 8466 || i == 8470 || i == 8473 || i == 8475 ||
                        i == 8477 || i == 8479 || i == 8480 || i == 8481 || i == 8482 || i == 8483 || i == 8486 || i == 8488 || i == 8490 || i == 8491 ||
                        i == 8492)
                    {
                    }
                    else
                    {
                        outPacket.WriteShort(i);
                    }
                }
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
    }
}