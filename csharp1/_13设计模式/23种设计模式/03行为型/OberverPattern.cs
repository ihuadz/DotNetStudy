
using System;

/// <summary>
/// 观察者模式
/// </summary>
internal class OberverPattern
{
    /// <summary>
    /// 观察者模式
    /// </summary>
    /// <remarks>
    /// 也叫发布-订阅模式，定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象
    /// 
    /// 优点：观察者和被观察者之间是抽象耦合；建立一套触发机制
    /// 缺点：观察者之间有过多的细节依赖、时间消耗、可能引起循环调用
    /// </remarks>
    internal static void Show()
    {
        ConcreteSubject subject = new ConcreteSubject();
        ConcreteObserverA observerA = new ConcreteObserverA();
        ConcreteObserverB observerB = new ConcreteObserverB();

        subject.Attach(observerA);
        subject.Attach(observerB);

        subject.Notify();
    }
}

/// <summary>
/// 具体观察者A
/// </summary>
internal class ConcreteObserverA : IObserver
{
    public void Update()
    {
        // 实现具体的更新逻辑
    }
}

/// <summary>
/// 具体观察者B
/// </summary>
internal class ConcreteObserverB : IObserver
{
    public void Update()
    {
        // 实现具体的更新逻辑
    }
}

/// <summary>
/// 抽象观察者
/// </summary>
internal interface IObserver
{
    void Update();
}

/// <summary>
/// 具体主题
/// </summary>
internal class ConcreteSubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

