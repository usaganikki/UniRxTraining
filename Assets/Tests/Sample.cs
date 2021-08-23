using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using UniRx;
using Assert = UnityEngine.Assertions.Assert;

public class Sample
{
    // A Test behaves as an ordinary method
    [Test]
    public void SampleSimplePasses()
    {
        var subject = new Subject<int>();

        var listNext = new List<int>();
        var listError = new List<Exception>();
        var listComplete = new List<Unit>();

        var subscription = subject
            .Subscribe(x => listNext.Add(x),
            ex => listError.Add(ex),
            () => listComplete.Add(new Unit()));

        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnCompleted();
        subject.OnNext(3);

        subscription.Dispose();

        Assert.AreEqual(2, listNext.Count);
        Assert.AreEqual(1, listNext[0]);
        Assert.AreEqual(2, listNext[1]);
        Assert.AreEqual(1, listComplete.Count);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SampleWithEnumeratorPasses()
    {
        var listNext = new List<Unit>();
        var listComplete = new List<Unit>();

        Observable.ReturnUnit()
            .Delay(TimeSpan.FromMilliseconds(1), Scheduler.ThreadPool)
            .Subscribe(
            x => listNext.Add(x),
            () => listComplete.Add(new Unit()));

        Assert.AreEqual(0, listNext.Count);

        var time = Time.time;
        yield return null;
        //while(true)
        //{
        //    if(Time.time - time > 1)
        //    {
        //        Debug.Log("Time.time " + Time.time);
        //        Debug.Log("time " + time);
        //        break;
        //    }
        //    yield return null;
        //}

        Assert.AreEqual(1, listNext.Count);
        Assert.AreEqual(1, listComplete.Count);
    }
}
