﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace CustServForm.CustComplaints
{
    //Store all Form Data before using Samanage API
    public class FormData
    {
        private string _Location;
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }

        private int _Membership;
        public int Membership
        {
            get
            {
                return _Membership;
            }
            set
            {
                _Membership = value;
            }
        }

        private string _Date;
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }

        private string _MobileOS;
        public string MobileOS
        {
            get
            {
                return _MobileOS;
            }
            set
            {
                _MobileOS = value;
            }
        }

        private string _websiteAccess;
        public string websiteAccess
        {
            get
            {
                return _websiteAccess;
            }
            set
            {
                _websiteAccess = value;
            }
        }

        private string _Origin;
        public string Origin
        {
            get
            {
                return _Origin;
            }
            set
            {
                _Origin = value;
            }
        }

        private string _OriginComment;
        public string OriginComment
        {
            get
            {
                return _OriginComment;
            }
            set
            {
                _OriginComment = value;
            }
        }

        private string _DispositionType;
            public string DispositionType
        {
            get
            {
                return _DispositionType;
            }
            set
            {
                _DispositionType = value;
            }
        }

        private string _DispositionIssue;
        public string DispositionIssue
        {
            get
            {
                return _DispositionIssue;
            }
            set
            {
                _DispositionIssue = value;
            }
        }

        private string _Reservation;
        public string Reservation
        {
            get
            {
                return _Reservation;
            }
            set
            {
                _Reservation = value;
            }
        }

        private string _CustEmail;

        public string CustEmail
        {
            get
            {
                return _CustEmail;
            }
            set
            {
                _CustEmail = value;
            }
        }

        private string _Ticket;
        public string Ticket {
            get
            {
                return _Ticket;
            }
            set
            {
                _Ticket = value;
            }
        }

        private string _Comments;

        public string Comments
        {
            get
            {
                return _Comments;
            }
            set
            {
                _Comments = value;
            }
        }

        public JObject FormatJSON(string form)
        {

            JObject body = JObject.FromObject(new
            {
                name = form + " Form",
                priority = "Low",
                description = CreateDescription(),
                custom_fields_values = new
                {
                    custom_fields_value = new[]
                    {
                        new
                        {
                            name = "Disposition Type",
                            value = DispositionType
                        },
                        new
                        {
                            name = "Disposition Issue",
                            value = DispositionIssue
                        }
                    }
                }
            });
            return body;
        }

        private string CreateDescription()
        {
            string fp = "No";
            if(_Membership == 1) { fp = "Yes"; }
            string body = "Location: " + _Location + "\n\nCustomer Email: " + _CustEmail + "\n\nFP Member: " + fp +
                "\n\nDate of Incident: " + _Date + "\n\nOrigin of Complaint: " + _Origin + "\n\nOrigin Description: " +
                _OriginComment + "\n\nDisposition Type: " + _DispositionType + "\n\nDisposition Issue: " + _DispositionIssue +
                "\n\nReservation: " + _Reservation;

            if (_Ticket!=null) {body += "\n\nTicket: " + _Ticket; }
            else if(_MobileOS != null) { body += "\n\nMobile OS: " + _MobileOS; }
            else if (_websiteAccess != null) { body += "\n\nWebsite accessed via: " + _websiteAccess; }

            body += "\n\nComments: " + _Comments;

            return body;
        }


        public void Fill(string loc, int member, string custEmail, string date, string origin, string originComment, string disp, string dispIssue, string comments, string CustName, string reservation, [Optional] string ticket, [Optional] string mobileOS, [Optional] string websiteAccess)
        {
            _Location = loc;
            _Membership = member;
            _Date = date;
            _Origin = origin;
            _OriginComment = originComment;
            _DispositionType = disp;
            _DispositionIssue = dispIssue;
            _Comments = comments;
            _CustEmail = custEmail;
            _Reservation = reservation;
            _Ticket = ticket;
            _MobileOS = mobileOS;
            _websiteAccess = websiteAccess;
        }
    }
}