using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace EthernetLinkConfig.Classes
{
    class CallRecord
    {

        public static string Reception_String;
        public bool IsValid;

        public Match CallMatch;
        public Match DetailedMatch;

        // Properties
        public bool Detailed;
        public string DetailedType;
        public int Line;
        public string InboundOrOutboundOrBlock;
        public string StartOrEnd;
        public int Duration;
        public string CheckSum;
        public string RingType;
        public int RingNumber;
        public DateTime DateTime;
        public string PhoneNumber;
        public string Name;

        public bool InternalBlock;

        public CallRecord(string udp_string)
        {
            Reception_String = udp_string;
            InternalBlock = false;

            //------------------------------------------------------
            //    Full Call Records
            //------------------------------------------------------
            CallMatch = Regex.Match(Reception_String, @".*(\d\d) ([IO]) ([ESB]) (\d{4}) ([GB]) (.)(\d) (\d\d/\d\d \d\d:\d\d [AP]M) (.{8,15})(.*)");
            //                                              |      |       |       |      |      |               |                     |     |
            //                                              01 Line        03 Start/End/Block    06 Ring(T#)     08 Datetime start     09 Phone Number
            //                                                     02 Inbound/Outbound    05 Checksum                                        10 Name
            //                                                                     04 Duration                                               
            // 

            if (CallMatch.Success)
            {
                Detailed = false;
                IsValid = true;

                Line = int.Parse(CallMatch.Groups[1].Value.ToString());

                if (CallMatch.Groups[2].Value == "I")
                {
                    InboundOrOutboundOrBlock = "I";
                }
                else if (CallMatch.Groups[2].Value == "O")
                {
                    InboundOrOutboundOrBlock = "O";
                }
                else
                {
                    InboundOrOutboundOrBlock = "B";
                }

                if (CallMatch.Groups[3].Value == "S")
                {
                    StartOrEnd = "S";
                }
                else
                {
                    StartOrEnd = "E";
                }

                Duration = int.Parse(CallMatch.Groups[4].Value.ToString());
                CheckSum = CallMatch.Groups[5].Value;
                RingType = CallMatch.Groups[6].Value;
                RingNumber = int.Parse(CallMatch.Groups[7].Value.ToString());

                DateTime = DateTime.ParseExact(CallMatch.Groups[8].Value.ToString(), "MM/dd hh:mm tt", new CultureInfo("en-US"));

                PhoneNumber = CallMatch.Groups[9].Value;
                Name = CallMatch.Groups[10].Value;

                return;
            }

            //------------------------------------------------------
            //    Detailed Records
            //------------------------------------------------------
            DetailedMatch = Regex.Match(Reception_String, @".*(\d\d) ([NFR]) {13}(\d\d/\d\d \d\d:\d\d:\d\d)");

            if (DetailedMatch.Success)
            {
                Detailed = true;
                IsValid = true;

                Line = int.Parse(DetailedMatch.Groups[1].Value.ToString());
                DetailedType = DetailedMatch.Groups[2].Value;

                var date = DetailedMatch.Groups[3].Value.ToString();
                if(date.Contains("00/00"))
                {
                    IsValid = false;
                    return;
                }

                DateTime = DateTime.ParseExact(date, "MM/dd HH:mm:ss", new CultureInfo("en-US"));

                return;
            }

            IsValid = false;

        }

        // Getters
        public bool IsInbound()
        {
            if (InboundOrOutboundOrBlock == "I") return true;
            return false;
        }

        public bool IsOutbound()
        {
            if (InboundOrOutboundOrBlock == "O") return true;
            return false;
        }

        public bool IsInternalBlock()
        {
            if (InboundOrOutboundOrBlock == "B") return true;
            return false;
        }

        public bool IsStartRecord()
        {
            if (StartOrEnd == "S") return true;
            return false;
        }

        public bool IsEndRecord()
        {
            if (StartOrEnd == "E") return true;
            return false;
        }
    }
}
