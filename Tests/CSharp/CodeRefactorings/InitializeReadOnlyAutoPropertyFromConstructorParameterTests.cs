using NUnit.Framework;
using RefactoringEssentials.CSharp.CodeRefactorings;

namespace RefactoringEssentials.Tests.CSharp.CodeRefactorings
{
    [TestFixture]
    public class InitializeReadOnlyAutoPropertyFromConstructorParameterTests : CSharpCodeRefactoringTestBase
    {
        [Test]
        public void InitialiseInteger()
        {
            Test<InitializeReadOnlyAutoPropertyFromConstructorParameterCodeRefactoringProvider>(@"
class Foo
{
    public Foo(int $x, int y)
    {
    }
}", @"
class Foo
{
    public int X { get; }

    public Foo(int x, int y)
    {
        X = x;
    }
}");
        }

        [Test]
        public void InitialiseInterface()
        {
            Test<InitializeReadOnlyAutoPropertyFromConstructorParameterCodeRefactoringProvider>(@"
class Foo
{
    public Foo(int x, ICedd $cedd)
    {
    }
}", @"
class Foo
{
    public ICedd Cedd { get; }

    public Foo(int x, ICedd cedd)
    {
        Cedd = cedd;
    }
}");
        }

        [Test]
        public void NotInParameterList()
        {
            TestWrongContext<InitializeReadOnlyAutoPropertyFromConstructorParameterCodeRefactoringProvider>(@"
class Foo
{
    public $Foo(int x, int y)
    {
    }
}");
        }

        [Test]
        public void NotInParameterValue()
        {
            TestWrongContext<InitializeReadOnlyAutoPropertyFromConstructorParameterCodeRefactoringProvider>(@"
class Foo
{
    public Foo($int x, int y)
    {
    }
}");
        }

        [Test]
        public void NotInConstructor()
        {
            TestWrongContext<InitializeReadOnlyAutoPropertyFromConstructorParameterCodeRefactoringProvider>(@"
class Foo
{
    public void Foo(int $x, int y)
    {
    }
}");
        }
    }
}

