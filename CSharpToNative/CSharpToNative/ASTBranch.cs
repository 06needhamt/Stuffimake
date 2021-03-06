﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpToNative
{
    public class ASTBranch<T1, T2, T3, T4> : Branch<T1, T2>
    {
        bool isroot = false;
        //static Type T4;
        public ASTBranch()
        {
            try
            {
                throw new InvalidOperationException("Cannot Create a branch without tokens or tree");
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();
            }
        }
        public ASTBranch(string[] tokens, AST<T1, T2, T3, T4> tree)
        {
            List<string> operators = new List<string>(new string[] { "=", "!=", "==", "+", "-", "*", "/", "++#", "#++", "--#", "#--", ">", "<", ">=", "<=", "&&", "&", "||", "|", "!", "~", "^", "+=", "-=", "*=", "/=", "<<", ">>", "%=", "&=", "|=", "^=", "<<=", ">>=", "?:", ".", "," });
            int times = 0;
            int index = 0;
            tree = new AST<T1, T2, T3, T4>();
            EnumAccessModifiers eprotval = EnumAccessModifiers.NO_MODIFIER;
            EnumTypes etypeval = EnumTypes.NO_TYPE;
            EnumOperator eopval = EnumOperator.NO_OPERATOR;
            if (tokens == null)
            {

            }
            for (int i = 0; i < tokens.Length; i++)
            {
                if (Enum.IsDefined(typeof(EnumAccessModifiers),tokens[i].ToUpper()))
                {
                    eprotval = (EnumAccessModifiers) Enum.Parse(typeof(EnumAccessModifiers),tokens[i].ToUpper());
                    
                }
                else if (Enum.IsDefined(typeof(EnumTypes),tokens[i].ToUpper()))
                {
                    etypeval = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[i].ToUpper());
                }
                else if (operators.Contains(tokens[i]))
                {
                    
                    for (int j = 0; j < operators.Count; j++)
                    {
                        if (operators[j] == tokens[i])
                        {
                            index = j;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    eopval = (EnumOperator) index;
                }
                else
                {
                    if (times == 0)
                    {
                        this.name = tokens[i];                    
                    }
                    else if (times == 1)
                    {
                        this.Value = tokens[i];
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                this.type = etypeval;
                this.operation = eopval;
                this.protectionlevel = eprotval;
                Console.WriteLine(Convert.ToString(this.type));
                Console.WriteLine(Convert.ToString(this.operation));
                Console.WriteLine(Convert.ToString(this.protectionlevel));
                Console.WriteLine(this.name);
                Console.WriteLine(this.Value);
                // Console.ReadKey();
            }
            
            if (tree.ASTbranches.Count == 0)
            {
                this.isroot = true;
            }
            else
            {
                this.isroot = false;
            }
            tree.ASTbranches.Add(this); 

            /* EnumAccessModifiers eprotval = EnumAccessModifiers.NO_MODIFIER;
            EnumTypes etypeval = EnumTypes.NO_TYPE;
            EnumOperator eopval = EnumOperator.NO_OPERATOR;

            if (tokens.Contains(Convert.ToString(EnumTypes.STATIC)) && tokens.Contains(Convert.ToString(EnumKeywords.VOID)))
            {
                //int protval = Convert.ToInt32(tokens[0]);
                eprotval = (EnumAccessModifiers)Enum.Parse(typeof(EnumAccessModifiers), tokens[0].ToUpper());
                //int typeval = Convert.ToInt32(tokens[1]);
                etypeval = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[1].ToUpper() + tokens[2].ToUpper());
                //int opval = Convert.ToInt32(tokens[2]);
                eopval = EnumOperator.NO_OPERATOR;
                this.name = tokens[4];
                this.Value = null;
            }
            else if (tokens.Contains(Convert.ToString(EnumTypes.STATIC)))
            {


                //int protval = Convert.ToInt32(tokens[0]);
                eprotval = (EnumAccessModifiers)Enum.Parse(typeof(EnumAccessModifiers), tokens[0].ToUpper());
                //int typeval = Convert.ToInt32(tokens[1]);
                etypeval = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[1].ToUpper() + "_" + tokens[2].ToUpper());
                //int opval = Convert.ToInt32(tokens[2]);
                eopval = EnumOperator.NO_OPERATOR; //(EnumOperator)Enum.Parse(typeof(EnumOperator), tokens[3].ToUpper());
                this.name = tokens[4];
                if (tokens.Length > 5)
                {
                    this.Value = tokens[5];
                }
                else
                {
                    this.Value = null;
                }
            }
            else
            { 
                if ((int)eprotval > 2)
                {
                    this.protectionlevel = EnumAccessModifiers.NO_MODIFIER;
                }
                else
                {
                    this.protectionlevel = (EnumAccessModifiers)Enum.Parse(typeof(EnumAccessModifiers), tokens[0].ToUpper());
                }

                if ((int)etypeval > 12)
                {
                    this.type = EnumTypes.NO_TYPE;
                }
                else if (etypeval == EnumTypes.STATIC_VOID)
                {
                    this.type = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[1].ToUpper() + "_" + tokens[2].ToUpper());
                }

                else if(etypeval == EnumTypes.STATIC || tokens[1].ToUpper().Equals("STATIC"))
                {
                    if (tokens[2].ToUpper().Equals("CONST"))
                    {
                        this.type = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[3].ToUpper());
                    }
                    else
                    {
                        this.type = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[2].ToUpper());
                    }
                }
                else if (etypeval == EnumTypes.CONST || tokens[1].ToUpper().Equals("CONST"))
                {
                    //if (tokens[2].ToUpper().Equals("CONST"))
                    //{
                    //    this.type = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[3].ToUpper());
                    //}

                    this.type = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[2].ToUpper());
                  
                }

                else
                {
                    this.type = (EnumTypes)Enum.Parse(typeof(EnumTypes), tokens[1].ToUpper());
                }


                if ((int)eopval >= 36 || (int)eopval < 0)
                {
                    this.operation = EnumOperator.NO_OPERATOR;
                }
                else
                {
                    this.operation = (EnumOperator)Enum.Parse(typeof(EnumOperator), tokens[2].ToUpper());
                }*/
            
           
        }

    }
}
