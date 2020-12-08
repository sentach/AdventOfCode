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
                Console.WriteLine($"Sentencia {Code[_ind]} Acc = {_acc} Ind = {_ind}");
                switch(sentence.InstruCode)
                {
                    case Sentence.Codes.acc:
                    case Sentence.Codes.nop:
                        acc += sentence.Arg;
                        nextInst = _ind +1;
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

        private static Sentence GetSentence(string v)
        {
            var l = v.Split(' ');
            int arg = Convert.ToInt32(l[1]);
            if (l[0] == "nop") { return new Sentence { InstruCode = Sentence.Codes.nop, Arg = 0 }; }
            else if (l[0] == "acc"){ return new Sentence { InstruCode = Sentence.Codes.acc, Arg = arg };}
            else if (l[0] == "jmp") { return new Sentence { InstruCode = Sentence.Codes.jmp, Arg = arg }; }
            throw new ArgumentException("Instruccion no incluida");
        }
    }
}
