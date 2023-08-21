internal class Program
{
    static void Main(string[] args)
    {
        string name = string.Empty;
        do
        {
            Console.WriteLine("请输入某人名字(全名, 例如赵本山，刘玄德……):");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));

        var resultGuess = Guess(name).ToString();


        Console.WriteLine("Hello, World!");
        Console.ReadLine();
    }



    /// <summary>
    /// 判断该人男女的概率
    /// </summary>
    /// <param name="full_name">输入的一个人的姓名</param>
    /// <returns></returns>
    public static (hmGender 性别, double 概率) Guess(string full_name)
    {
        string firstname = full_name.Substring(1);

        double pf = ProbForGender(firstname, 0);
        double pm = ProbForGender(firstname, 1);

        if (pm >= pf) //明显是男性
        {
            return (hmGender.Male, pm / (pm + pf));
        }
        else // 意味着pm < pf 应为女性
        {
            return (hmGender.Female, pf / (pm + pf));
        }

    }

    /// <summary>
    /// 计算当前名字是某个性别的概率
    /// </summary>
    /// <param name="justName">抛开姓以外, 隶属于名的部分</param>
    /// <param name="gender">0==女性, 1==男性</param>
    /// <returns>返回值是一个百分比数字, 0-1之间的数值, 表示一个概率</returns>
    public static double ProbForGender(string justName, int gender = 0)
    {
        double p = 0D;
        if (gender == 0)
        {
            p = (double)CharFrequency.maleTotal / CharFrequency.total;
        }
        else// if (gender == 1)
        {
            p = (double)CharFrequency.femaleTotal / CharFrequency.total;
        }



        foreach (char c in justName)
        {
            var valuevalue = CharFrequency.dic_frequency[c.ToString()];
            if (gender == 0)//! 是女性
            {
                p *= valuevalue.Item1;
            }
            else if (gender == 1)//! 是男性
            {
                p *= valuevalue.Item2;
            }
        }

        return p;
    }


    /// <summary>
    /// 性别定义的枚举值
    /// </summary>
    public enum hmGender
    {
        /// <summary>
        /// 女性
        /// </summary>
        Female = 0,
        /// <summary>
        /// 男性
        /// </summary>
        Male = 1,

    }





}
