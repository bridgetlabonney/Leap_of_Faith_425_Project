using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ButtonTest : InputTestFixture
{
    // A Test behaves as an ordinary method
    GameObject character = Resources.Load<GameObject>("Player");
    GameObject button = Resources.Load<GameObject>("Button");
    Keyboard keyboard;
    [SetUp]
    public override void Setup()
    {
        SceneManager.LoadScene("Scenes/ButtonTesting");
        base.Setup();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }
    [UnityTest]
    public IEnumerator ButtonTestWithEnumeratorPasses()
    {
        GameObject charecterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);
        GameObject buttonInstance = GameObject.Instantiate(button, Vector3.zero, Quaternion.identity);

        Press(keyboard.fKey);
        yield return new WaitForSeconds(1f);
        Release(keyboard.fKey);
        yield return new WaitForSeconds(1f);

        Assert.That(buttonInstance.GetComponent<button>().switched, Is.EqualTo(true));
    }
}
