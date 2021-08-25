using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using UniRx;
//using Assert = UnityEngine.Assertions.Assert;

public class Sample
{
    // A Test behaves as an ordinary method
    [Test]
    public void SampleSimplePasses()
    {
        Assert.That(1 < 10);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SampleWithEnumeratorPasses()
    {
        Assert.That(1 < 10);
        yield return null;
        Assert.That(2 < 10);
        yield return null;
        Assert.That(3 < 10);
    }
}
