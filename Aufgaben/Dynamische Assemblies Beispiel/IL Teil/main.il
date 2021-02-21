.assembly extern mscorlib
{
	.publickeytoken = (b7 7a 5c 56 19 34 e0 89)
	.ver 4:0:0:0
}

.assembly CIL_Demo
{
}

.module CIL_Demo.exe

.namespace DemoNamespace
{
	.class Program extends [mscorlib]System.Object
	{
		.method static void Main(string[] args) cil managed
		{
			//Hello World
			.entrypoint
	
			ldstr "Hello World"
			call void [mscorlib]System.Console::WriteLine(string)	
			
			call int32 DemoNamespace.Program::GetNumber()	
			call void [mscorlib]System.Console::WriteLine(int32)

			call string [mscorlib]System.Console::ReadLine()
			pop
	
			newobj instance void DemoNamespace.TestClass::.ctor()
			ldc.i4 12345
			call instance int32 DemoNamespace.TestClass::GetNumber(int32)
			call void [mscorlib]System.Console::WriteLine(int32)
	
			ret
		}

		.method static int32 GetNumber() cil managed
		{
			ldc.i4 1337
			ret
		}
	}
	
	.class TestClass extends [mscorlib]System.Object
	{
		.method void .ctor() cil managed
		{
			ldarg.0 
			call instance void [mscorlib]System.Object::.ctor()
			ret
		}

		.method int32 GetNumber(int32) cil managed
		{
			ldarg.1
			ret
		}
	}
}