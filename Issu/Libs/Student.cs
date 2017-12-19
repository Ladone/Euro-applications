using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Issu.Libs
{
    class Student
    {
       
        private StringMultiLanguage _lastname;
        private StringMultiLanguage _firstname;
        private StringMultiLanguage _prevDocument;
        private StringMultiLanguage _durationOfTraining;

        private DateTime _birthday;
        private String _serialDiploma;
        private String _numberDiploma;
        private String _numberAddition;
        private String _prevSerialNumberAddition;

        public Student()
        {
            this._lastname              = new StringMultiLanguage();
            this._firstname             = new StringMultiLanguage();
            this._prevDocument          = new StringMultiLanguage();
            this._durationOfTraining    = new StringMultiLanguage();

            this._birthday                  = new DateTime();
            this._serialDiploma             = "";
            this._numberDiploma             = "";
            this._prevSerialNumberAddition  = "";


        }

        public StringMultiLanguage Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public StringMultiLanguage Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public StringMultiLanguage PrevDocument
        {
            get { return _prevDocument; }
            set { _prevDocument = value; }
        }

        public StringMultiLanguage DurationOfTraining
        {
            get { return _durationOfTraining; }
            set { _durationOfTraining = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public String SerialDiploma
        {
            get { return _serialDiploma; }
            set { _serialDiploma = value; }
        }

        public String NumberDiploma
        {
            get { return _numberDiploma; }
            set { _numberDiploma = value; }
        }

        public String PrevSerialNumberAddition
        {
            get { return _prevSerialNumberAddition; }
            set { _prevSerialNumberAddition = value; }
        }
    }

}
