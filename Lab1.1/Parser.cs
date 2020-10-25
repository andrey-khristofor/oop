using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace Lab1._1
{
    //клас, що виключає помилки для анализатора
    class ParserException : ApplicationException
    {
        public ParserException(string str) : base(str) { }
        public override string ToString()
        { return Message; }
    }
    class Parser
    {
        enum Types { NONE, DELIMITER, VARIABLE, NUMBER }; //лексеми.
        enum Errors { SYNTAX, UNBALPARENS, NOEXP, DIVBYZERO }; // помилки.
        string exp; // рядок виразу
        int expIdx; // поточний індекс у виразі
        string token; // поточна лексема
        Types tokType; // тип лексеми
                       // Масив для змінних

        public Dictionary<string, double> Vars = new Dictionary<string, double> { };
        double[] vars = new double[26];
        public Parser()
        {
            // Ініціалізуємо змінні нульовими значеннями.
            for (int i = 0; i < vars.Length; i++)
                vars[i] = 0.0;
        }

        bool IfBool(double a, double b)
        {
            if ((a == 0 && b == 0) || (a == 0 && b == 1) || (a == 1 && b == 0) || (a == 1 && b == 1))
                return true;
            return false;
        }

        /* Точка входу аналізатора. */
        public double Evaluate(string expstr)
        {
            double result;
            exp = expstr;


            exp = exp.Replace(">=", "}");
            exp = exp.Replace("<=", "{");
            exp = exp.Replace("=", "~");
            exp = exp.Replace("#", "=");
            exp = exp.Replace("<>", "?");
            exp = exp.Replace("not", "!");
            exp = exp.Replace("or", "|");
            exp = exp.Replace("and", "&");

            expIdx = 0;
            try
            {
                GetToken();
                if (token == "")
                {
                    SyntaxErr(Errors.NOEXP); // Вираз відсутній
                    return 0.0;
                }
                EvalExp1(out result);
                if (token != "") /* остання лексема повинна бути нульова */
                    SyntaxErr(Errors.SYNTAX);
                return result;
            }
            catch (ParserException exc)
            {

                Console.WriteLine(exc);
                return 0.0;
            }
        }
        // Обробка присвоювання
        void EvalExp1(out double result)
        {
            string varIdx1;
            int varIdx;
            Types ttokType;
            string temptoken;
            if (tokType == Types.VARIABLE)
            {
                // зберегти стару лексему 
                temptoken = String.Copy(token);
                ttokType = tokType;
                // обчислити індекс змінної 
                varIdx1 = token;
                varIdx = Char.ToUpper(token[0]) - 'A';
                GetToken();
                if (token != "=")
                {
                    PutBack();// повернути поточну лексему  в поток
                    //відновити стару лексему - це не присвоювання
                    token = String.Copy(temptoken);
                    tokType = ttokType;
                }
                else
                {
                    GetToken();// одержати наступну частину виразу 
                    EvalBoolExp1(out result);
                    //if (Vars.ContainsKey(varIdx1))
                    varIdx1 = varIdx1.Replace(" ", "");
                    Vars[varIdx1] = result;
                    //else
                    //Vars.Add(varIdx1, result);
                    vars[varIdx] = result;
                    return;
                }
            }

            EvalBoolExp1(out result);
        }

        //обробка and i or

        void EvalBoolExp1(out double result)
        {
            string op;
            double partialResult;

            EvalBoolExp2(out result);
            while ((op = token) == "|" || op == "&")
            {
                GetToken();
                EvalBoolExp2(out partialResult);
                if (IfBool(result, partialResult))
                {
                    switch (op)
                    {
                        case "|":
                            if (result == 1 || partialResult == 1) result = 1;
                            else result = 0;
                            //result = result - partialResult;
                            break;
                        case "&":
                            if (result == 1 && partialResult == 1) result = 1;
                            else result = 0;
                            //result = result + partialResult;
                            break;
                    }
                }
            }
        }

        //обробка not

        void EvalBoolExp2(out double result)
        {
            string op;
            double partialResult;

            EvalBoolExp3(out result);
            while ((op = token) == "!")
            {
                GetToken();
                EvalBoolExp3(out partialResult);
                if (partialResult == 1) partialResult = 0;
                else partialResult = 1;
            }
        }

        //обробка = i <>

        void EvalBoolExp3(out double result)
        {
            string op;
            double partialResult;

            EvalBoolExp4(out result);
            while ((op = token) == "~" || op == "?")
            {
                GetToken();
                EvalBoolExp4(out partialResult);
                switch (op)
                {
                    case "~":
                        if (result == partialResult) result = 1;
                        else result = 0;
                        //result = result - partialResult;
                        break;
                    case "?":
                        if (result != partialResult) result = 1;
                        else result = 0;
                        //result = result + partialResult;
                        break;
                }
            }
        }

        //обробка >= i <=

        void EvalBoolExp4(out double result)
        {
            string op;
            double partialResult;

            EvalBoolExp5(out result);
            while ((op = token) == "}" || op == "{")
            {
                GetToken();
                EvalBoolExp5(out partialResult);
                switch (op)
                {
                    case "}":
                        if (result >= partialResult) result = 1;
                        else result = 0;
                        //result = result - partialResult;
                        break;
                    case "{":
                        if (result <= partialResult) result = 1;
                        else result = 0;
                        //result = result + partialResult;
                        break;
                }
            }
        }

        //обробка > i <

        void EvalBoolExp5(out double result)
        {
            string op;
            double partialResult;

            EvalExp2(out result);
            while ((op = token) == ">" || op == "<")
            {
                GetToken();
                EvalExp2(out partialResult);
                switch (op)
                {
                    case ">":
                        if (result > partialResult) result = 1;
                        else result = 0;
                        //result = result - partialResult;
                        break;
                    case "<":
                        if (result < partialResult) result = 1;
                        else result = 0;
                        //result = result + partialResult;
                        break;
                }
            }
        }


        // Додавання або віднімання двох доданків
        void EvalExp2(out double result)
        {
            string op;
            double partialResult;

            EvalExp3(out result);
            while ((op = token) == "+" || op == "-")
            {
                GetToken();
                EvalExp3(out partialResult);
                switch (op)
                {
                    case "-":
                        result = result - partialResult;
                        break;
                    case "+":
                        result = result + partialResult;
                        break;
                }
            }
        }
        // Выполняем умножение или деление двух множителей.
        void EvalExp3(out double result)
        {
            string op;
            double partialResult = 0.0;
            EvalExp4(out result);
            while ((op = token) == "*" || op == "/" || op == "%")
            {
                GetToken();
                EvalExp4(out partialResult);
                switch (op)
                {
                    case "*":
                        result = result * partialResult;
                        break;
                    case "/":
                        if (partialResult == 0.0)
                            SyntaxErr(Errors.DIVBYZERO);
                        result = result / partialResult;
                        break;
                    case "%":
                        if (partialResult == 0.0)
                            SyntaxErr(Errors.DIVBYZERO);
                        result = (int)result % (int)partialResult;
                        break;
                }
            }
        }
        // Піднесення до степені 
        void EvalExp4(out double result)
        {
            double partialResult, ex;
            int t;
            EvalExp5(out result);
            if (token == "^")
            {
                GetToken();
                EvalExp4(out partialResult);
                ex = result;
                if (partialResult == 0.0)
                {
                    result = 1.0;
                    return;
                }
                for (t = (int)partialResult - 1; t > 0; t--)
                    result = result * (double)ex;
            }
        }

        // Множення унарних операторів + й -. 
        void EvalExp5(out double result)
        {
            string op;

            op = "";
            if ((tokType == Types.DELIMITER) && token == "+" || token == "-")
            {
                op = token;
                GetToken();
            }
            EvalExp6(out result);
            if (op == "-") result = -result;
        }
        // Обчислення виразів в дужках
        void EvalExp6(out double result)
        {
            if ((token == "("))
            {
                GetToken();
                EvalExp2(out result);
                if (token != ")")
                    SyntaxErr(Errors.UNBALPARENS);
                GetToken();
            }
            else Atom(out result);
        }
        // Одержання значення числа, або змінної 
        void Atom(out double result)
        {
            switch (tokType)
            {
                case Types.NUMBER:
                    try
                    {
                        result = Double.Parse(token);
                    }
                    catch (FormatException)
                    {
                        result = 0.0;
                        SyntaxErr(Errors.SYNTAX);
                    }
                    GetToken();
                    return;
                case Types.VARIABLE:
                    result = FindVar(token);
                    GetToken();
                    return;
                default:
                    result = 0.0;
                    SyntaxErr(Errors.SYNTAX);
                    break;
            }
        }
        // Повертаємо значення змінної
        double FindVar(string vname)
        {
            if (!Char.IsLetter(vname[0]))
            {
                SyntaxErr(Errors.SYNTAX);
                return 0.0;
            }
            if (!(Vars.ContainsKey(vname)))
                Vars.Add(vname, 0);
            return Vars[vname];
            //return vars[Char.ToUpper(vname[0]) - 'A'];
        }
        //повертаємо лексему у вхідний потік.
        void PutBack()
        {
            for (int i = 0; i < token.Length; i++) expIdx--;
        }
        // Обробляємо синтаксичну помилку
        void SyntaxErr(Errors error)
        {
            string[] err ={
                         "Синтаксична помилка",
                         "Дисбаланс дужок",
                         "Вираз відсутнів",
                         "Ділення на нуль"};
            throw new ParserException(err[(int)error]);
        }
        // отримуємо наступну лексему
        void GetToken()
        {
            tokType = Types.NONE;
            token = "";
            if (expIdx == exp.Length) return; //кінець виразу
            // пропускаємо пробіл
            while (expIdx < exp.Length && Char.IsWhiteSpace(exp[expIdx])) ++expIdx;
            // Хвостовий пробіл 
            if (expIdx == exp.Length) return;
            if (IsDelim(exp[expIdx]))
            {
                token += exp[expIdx];
                expIdx++;
                tokType = Types.DELIMITER;
            }
            else if (Char.IsLetter(exp[expIdx]))
            {
                // Це змінна?
                while (!IsDelim(exp[expIdx]))
                {
                    token += exp[expIdx];
                    expIdx++;
                    if (expIdx >= exp.Length) break;
                }
                tokType = Types.VARIABLE;
            }
            else if (Char.IsDigit(exp[expIdx]))
            {
                // Це число?
                while (!IsDelim(exp[expIdx]))
                {
                    token += exp[expIdx];
                    expIdx++;
                    if (expIdx >= exp.Length) break;
                }
                tokType = Types.NUMBER;
            }
            token = token.Replace(" ", "");
        }
        // Метод повертає значення true,
        // якщо с - роздільник
        bool IsDelim(char c)
        {
            if (("+-/*%^=()><~}{?!|&".IndexOf(c) != -1))
                return true;
            return false;
        }
    }
}
