No NUnit, os **asserts** são usados para validar os resultados esperados dos testes. Aqui estão os principais comandos de **asserts** no NUnit com exemplos práticos:

---

## **1. Comparação de Valores**
    🔹 Verifica se dois valores são iguais.
    ```csharp
    Assert.That(10 + 5, Is.EqualTo(15));
    Assert.That("Bruno".ToUpper(), Is.EqualTo("BRUNO"));
    Assert.That(true, Is.EqualTo(true));
    ```

    🔹 Também pode usar `AreEqual`:
    ```csharp
    Assert.AreEqual(10 + 5, 15);
    ```

    ---

## **2. Verificar Diferentes (`Not Equal`)**
    🔹 Confirma que dois valores **não** são iguais.
    ```csharp
    Assert.That(10 + 5, Is.Not.EqualTo(20));
    Assert.That("Bruno", Is.Not.EqualTo("Carlos"));
    ```

    🔹 Ou usando `AreNotEqual`:
    ```csharp
    Assert.AreNotEqual(10 + 5, 20);
    ```

    ---

## **3. Comparação Numérica**
    🔹 Maior que, menor que, maior ou igual, menor ou igual:
    ```csharp
    Assert.That(10, Is.GreaterThan(5));
    Assert.That(10, Is.LessThan(20));
    Assert.That(10, Is.GreaterThanOrEqualTo(10));
    Assert.That(5, Is.LessThanOrEqualTo(5));
    ```

    ---

## **4. Verificar Valores Nulos e Não Nulos**
    🔹 Confirma se um valor **é nulo** ou **não é nulo**:
    ```csharp
    string nome = null;
    Assert.That(nome, Is.Null);

    nome = "Bruno";
    Assert.That(nome, Is.Not.Null);
    ```

    ---

## **5. Verificar Valores Booleanos**
    🔹 Testa se um valor é **verdadeiro** ou **falso**:
    ```csharp
    Assert.That(5 > 3, Is.True);
    Assert.That(2 > 5, Is.False);
    ```

    ---

## **6. Verificar Conteúdo de Strings**
    🔹 Testa se uma string contém outra string:
    ```csharp
    Assert.That("Bruno Silva", Does.Contain("Silva"));
    Assert.That("Bruno", Does.Not.Contain("Carlos"));
    ```

    🔹 Testa se uma string começa ou termina com um valor específico:
    ```csharp
    Assert.That("Bruno Silva", Does.StartWith("Bruno"));
    Assert.That("Bruno Silva", Does.EndWith("Silva"));
    ```

    ---

## **7. Verificar Listas e Arrays**
    🔹 Testa se um array contém um valor:
    ```csharp
    int[] numeros = { 1, 2, 3, 4, 5 };
    Assert.That(numeros, Does.Contain(3));
    ```

    🔹 Testa se um array tem um número exato de elementos:
    ```csharp
    Assert.That(numeros.Length, Is.EqualTo(5));
    ```

    🔹 Testa se uma coleção **não está vazia**:
    ```csharp
    List<string> nomes = new() { "Bruno", "Carlos" };
    Assert.That(nomes, Is.Not.Empty);
    ```

    ---

## **8. Lançamento de Exceções**
    🔹 Testa se um código gera uma exceção específica:
    ```csharp
    Assert.Throws<DivideByZeroException>(() => {
        int x = 10 / 0;
    });
    ```

    🔹 Testa se **nenhuma exceção** foi lançada:
    ```csharp
    Assert.DoesNotThrow(() => {
        int x = 10 / 2;
    });
    ```

    ---

    ## **Resumo dos Comandos**
    | Assert                          | Descrição |
    |---------------------------------|-----------|
    | `Assert.That(valor, Is.EqualTo(x))` | Verifica igualdade |
    | `Assert.That(valor, Is.Not.EqualTo(x))` | Verifica diferença |
    | `Assert.That(valor, Is.GreaterThan(x))` | Maior que |
    | `Assert.That(valor, Is.LessThan(x))` | Menor que |
    | `Assert.That(valor, Is.Null)` | Verifica se é `null` |
    | `Assert.That(valor, Is.Not.Null)` | Verifica se **não** é `null` |
    | `Assert.That(condicao, Is.True)` | Verifica se a condição é `true` |
    | `Assert.That(condicao, Is.False)` | Verifica se a condição é `false` |
    | `Assert.That(texto, Does.Contain("X"))` | Verifica se contém um valor |
    | `Assert.That(texto, Does.Not.Contain("X"))` | Verifica se **não** contém um valor |
    | `Assert.Throws<TipoExcecao>(delegate)` | Verifica se uma exceção é lançada |

    ---

### **Exemplo Completo**
```csharp
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    namespace ProjetoNUnit
    {
        public class Testes
        {
            [Test]
            public void TesteDeValores()
            {
                Assert.That(5 + 5, Is.EqualTo(10));
                Assert.That(10, Is.GreaterThan(5));
                Assert.That("Bruno", Does.StartWith("B"));
            }

            [Test]
            public void TesteDeExcecao()
            {
                Assert.Throws<DivideByZeroException>(() =>
                {
                    int x = 10 / 0;
                });
            }

            [Test]
            public void TesteLista()
            {
                List<string> nomes = new() { "Bruno", "Carlos" };
                Assert.That(nomes, Does.Contain("Bruno"));
                Assert.That(nomes, Is.Not.Empty);
            }
        }
    }