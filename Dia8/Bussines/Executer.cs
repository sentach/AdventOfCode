using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class Executer
    {
        private class Sentence
        {
            public enum Codes { nop, acc, jmp}
            public Codes InstruCode { get; set; }
            public int Arg { get; set; }
        }

        public List<string> Code { get; set; }
        private int _acc;
        private int _ind;
        List<int> instru;
        public Executer(List<string> code)
        {
            Code = code;
        }

        public int Resolutor()
        {
            int i =0;
            for(;i<601; i++)
            {
                var s = GetSentence(Code[i]);
                if(s.InstruCode==Sentence.Codes.nop || s.InstruCode==Sentence.Codes.jmp)
                {
                    int jump = (i + s.Arg);
                    if (jump<=129 && jump>=133)
                    {
                        break;
                    }
                }
            }
            return i;
        }

        public int Execute()
        {
            _acc = 0;
            _ind = 0;
            instru = new List<int>();
            while(_ind < Code.Count)
            {
                int nextInst = 0;
                var acc = _acc;
                var sentence = GetSentence(Code[_ind]);
                //Console.WriteLine($"Sentencia {Code[_ind]} Acc = {_acc} Ind = {_ind}");
                switch(sentence.InstruCode)
                {
                    case Sentence.Codes.nop:
                        nextInst = _ind + 1;
                        break;
                    case Sentence.Codes.acc:                    
                        acc += sentence.Arg;
                        nextInst = _ind + 1;
                        break;
                    case Sentence.Codes.jmp:
                        nextInst = _ind + sentence.Arg;
                        break;
                }
                if(instru.Contains(_ind))
                {                    
                    break;
                }
                instru.Add(_ind);
                _ind = nextInst;
                _acc = acc;
            }

            return _acc;
        }

        public bool Execute3(out int acc)
        {
            _acc = 0;
            _ind = 0;
            acc = 0;
            instru = new List<int>();
            while (_ind < Code.Count)
            {
                int nextInst = 0;
                acc = _acc;
                var sentence = GetSentence(Code[_ind]);
                //Console.WriteLine($"Sentencia {Code[_ind]} Acc = {_acc} Ind = {_ind}");
                switch (sentence.InstruCode)
                {
                    case Sentence.Codes.nop:
                        nextInst = _ind + 1;
                        break;
                    case Sentence.Codes.acc:
                        acc += sentence.Arg;
                        nextInst = _ind + 1;
                        break;
                    case Sentence.Codes.jmp:
                        nextInst = _ind + sentence.Arg;
                        break;
                }
                if (instru.Contains(_ind))
                {
                    return false;
                }
                instru.Add(_ind);
                _ind = nextInst;
                _acc = acc;
            }

            acc = _acc;
            return true;
        }

        public int Solve2()
        {
            for (int i = 0; i < Code.Count; i++)
            {
                if (Code[i].StartsWith("acc")) { continue; }
                if (Code[i].StartsWith("nop")) { Code[i] = Code[i].Replace("nop", "jmp"); }
                else if (Code[i].StartsWith("jmp")) { Code[i] = Code[i].Replace("jmp", "nop"); }
                int result;
                if (Execute3(out result)) { return result; }
                if (Code[i].StartsWith("nop")) { Code[i] = Code[i].Replace("nop", "jmp"); }
                else if (Code[i].StartsWith("jmp")) { Code[i] = Code[i].Replace("jmp", "nop"); }
            }
            return 0;
        }

        public int Execute2()
        {
            _acc = 0;
            _ind = 0;
            bool cambio = false;
            while (_ind < Code.Count)
            {
                var sentence = GetSentence(Code[_ind]);
                Console.WriteLine($"Sentencia {Code[_ind]} Acc = {_acc} Ind = {_ind}");
                //if(_ind==124 && sentence.InstruCode == Sentence.Codes.jmp) { sentence.InstruCode = Sentence.Codes.nop; }
                if (!cambio && sentence.InstruCode == Sentence.Codes.jmp) { sentence.InstruCode = Sentence.Codes.nop; cambio = true; }

                switch (sentence.InstruCode)
                {
                    case Sentence.Codes.nop:
                        _ind++;
                        break;
                    case Sentence.Codes.acc:                    
                        _acc += sentence.Arg;
                        _ind++;
                        break;
                    case Sentence.Codes.jmp:
                        _ind += sentence.Arg;
                        break;
                }                
            }

            return _acc;
        }

        private static Sentence GetSentence(string v)
        {
            var l = v.Split(' ');
            int arg = Convert.ToInt32(l[1]);
            if (l[0] == "nop") { return new Sentence { InstruCode = Sentence.Codes.nop, Arg = arg }; }
            else if (l[0] == "acc"){ return new Sentence { InstruCode = Sentence.Codes.acc, Arg = arg };}
            else if (l[0] == "jmp") { return new Sentence { InstruCode = Sentence.Codes.jmp, Arg = arg }; }
            throw new ArgumentException("Instruccion no incluida");
        }
    }
}
