# ngender.net
根据中文的汉字判断这个人的性别，来源于observerss/ngender，我将它改为C#/Csharp版本


用法很简单：<br />
```csharp
        //纯靠概率学, 胜男会被认为男性(实际上叫这名字都应该是女的)
        var resultGuess1 = Guess("振国");
        var resultGuess2 = Guess("备");
        var resultGuess3 = Guess("常风");
        var resultGuess4 = Guess("不败");
        var resultGuess5 = Guess("胜男");
```

因为“胜男”这样的名字，我额外扩展一定手工指定，使用GuessWithFix方法自己解决问题。用法如下，两个方法也就是名字略微有区别。
```csharp
        //人工修订指定, 修改CharFrequency.cs中的appendFix的设置数据
        var resultGuess6 = GuessWithFix("胜男");
        var resultGuess7 = GuessWithFix("招娣");
```

注意!!!只输入名,不要输入姓
请看源码，超级简单。
祝大家使用愉快，如果想知道原理请看Python项目observerss/ngender的首页有详细说明。
