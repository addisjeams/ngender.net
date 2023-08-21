internal class Program
{
    static void Main(string[] args)
    {


        //纯靠概率学, 胜男会被认为男性(实际上叫这名字都应该是女的)
        var resultGuess1 = Guess("振国").ToString();
        var resultGuess2 = Guess("备").ToString();
        var resultGuess3 = Guess("常风").ToString();
        var resultGuess4 = Guess("不败").ToString();
        var resultGuess5 = Guess("胜男").ToString();

        //人工修订指定, 修改CharFrequency.cs中的appendFix的设置数据
        var resultGuess6 = GuessWithFix("胜男").ToString();
        var resultGuess7 = GuessWithFix("招娣").ToString();





        Console.WriteLine("Hello, World!");
        Console.ReadLine();
    }



    /// <summary>
    /// 判断该人男女的概率
    /// </summary>
    /// <param name="justName">输入的一个人的名, 只是名字, 不带姓, 比如刘备输入"备", 比如东方不败输入"不败"</param>
    /// <returns></returns>
    public static (hmGender 性别, double 概率) Guess(string justName)
    {
        double pf = ProbForGender(justName, 0);//作为女性评估概率
        double pm = ProbForGender(justName, 1);//作为男性评估概率

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
    /// 人工修订+概率判断该人男女
    /// </summary>
    /// <param name="justName">输入的一个人的名, 只是名字, 不带姓, 比如刘备输入"备", 比如东方不败输入"不败"</param>
    /// <returns></returns>
    public static (hmGender 性别, double 概率) GuessWithFix(string justName)
    {
        if (CharFrequency.dic_fix.TryGetValue(justName,out hmGender gender))
        {
            return (gender, 1.0d);//强制认为100%, 你们可以设置为80%也就是0.8
        }
        else
        {
            return Guess(justName);
        }
    }








    /// <summary>
    /// 计算当前名字是某个性别的概率
    /// </summary>
    /// <param name="justName">抛开姓以外, 隶属于名的部分</param>
    /// <param name="gender">0==女性, 1==男性</param>
    /// <returns>返回值是一个百分比数字, 0-1之间的数值, 表示一个概率</returns>
    private static double ProbForGender(string justName, int gender = 0)
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




}//class



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
