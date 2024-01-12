namespace _13设计模式._23种设计模式._03行为型;
internal class ChainOfResponsibilityPattern
{
    /// <summary>
    /// 责任链模式
    /// </summary>
    /// <remarks>
    /// 使多个对象都有机会处理请求，从而避免请求的发送者和接收者之间的耦合关系。
    /// 将这些对象连成一条链，并沿着这条链传递该请求，直到有一个对象处理它为止。
    /// 
    /// 优点：将请求和处理分开。请求者可以不用知道是谁处理的，处理者可以不用知道请求的全貌。
    /// 缺点：
    /// 1、性能问题，每个请求都是从链头遍历到链尾，特别是在链比较长的时候，性能是一个非常大的问题。
    /// 2、调试不很方便，特别是链条比较长，环节比较多的时候，由于采用了类似递归的方式，调试的时候逻辑可能比较复杂。
    /// </remarks>
    public static void Show()
    {
        Handler handler1 = new ConcreteHandler1();
        Handler handler2 = new ConcreteHandler2();
        Handler handler3 = new ConcreteHandler3();

        handler1.SetSuccessor(handler2);
        handler2.SetSuccessor(handler3);

        // Start the chain
        var response = handler1.HandleRequest(new Request(Level.Two));
        Console.WriteLine(response?.Msg);
    }
}

/// <summary>
/// 抽象处理者
/// </summary>
abstract class Handler
{
    private Handler? _successor;

    public void SetSuccessor(Handler successor)
    {
        this._successor = successor;
    }

    /// <summary>
    /// 处理请求的抽象方法
    /// </summary>
    /// <param name="request">请求</param>
    public Response HandleRequest(Request request)
    {
        Response response;

        //自己处理
        if (this.GetHandlerLevel() == request.Level)
        {
            response = this.Echo(request);
        }
        else
        {
            //给下一个处理者处理
            if (this._successor != null)
            {
                response = this._successor.HandleRequest(request);
            }
            else
            {
                response = new Response("没有合适的处理器");
            }
        }

        return response;
    }

    /// <summary>
    /// 处理级别
    /// </summary>
    /// <returns></returns>
    protected abstract Level GetHandlerLevel();

    /// <summary>
    /// 响应结果
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    protected abstract Response Echo(Request request);
}

/// <summary>
/// 具体处理者1
/// </summary>
class ConcreteHandler1 : Handler
{
    protected override Response Echo(Request request)
    {
        return new Response($"{request.Level} Response");
    }

    protected override Level GetHandlerLevel()
    {
        return Level.One;
    }
}

/// <summary>
/// 具体处理者2
/// </summary>
class ConcreteHandler2 : Handler
{

    protected override Response Echo(Request request)
    {
        return new Response($"{request.Level} Response");
    }

    protected override Level GetHandlerLevel()
    {
        return Level.Two;
    }
}

/// <summary>
/// 具体处理者3
/// </summary>
class ConcreteHandler3 : Handler
{

    protected override Response Echo(Request request)
    {
        return new Response($"{request.Level} Response");
    }

    protected override Level GetHandlerLevel()
    {
        return Level.Three;
    }
}

/// <summary>
/// 处理级别枚举
/// </summary>
enum Level
{
    One, Two, Three
}

/// <summary>
/// 请求
/// </summary>
class Request
{
    public Level Level;

    public Request(Level level)
    {
        Level = level;
    }

}

/// <summary>
/// 响应
/// </summary>
class Response
{
    public string Msg;

    public Response(string Msg)
    {
        this.Msg = Msg;
    }
}