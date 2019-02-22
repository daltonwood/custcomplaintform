using System;
using System.Collections.Generic;
using System.Linq;
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

        public dynamic FormatJSON()
        {

            string vals = ("{\"name\":\"Customer Complaint\",\"priority\":\"High\"");

            var body = new
            {
                name = "Customer Complaint",
                priority = "High",
                description = "Results from a customer complaint form",
                custom_fields_value = new {
                    name = "Membership",
                    value = "True"
                },
                custom_fields_values =new[]
                    { new
                        {
                            name = "Membership",
                            value = "True"
                        }
                    },
            };
            return body;
        }

        public void Fill(string loc, int member, string date, string origin, string originComment, string disp, string dispIssue, string comments)
        {
            _Location = loc;
            _Membership = member;
            _Date = date;
            _Origin = origin;
            _OriginComment = originComment;
            _DispositionType = disp;
            _DispositionIssue = dispIssue;
            _Comments = comments;
        }
    }
}