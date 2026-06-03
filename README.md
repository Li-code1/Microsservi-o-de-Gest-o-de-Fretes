# Microsserviço de Gestão de Fretes 🚚


Este é um microsserviço de produção moderno desenvolvido em **.NET 10** focado no cálculo e gerenciamento de rotas de entrega. O projeto destaca conceitos fundamentais de nuvem, segurança robusta, testabilidade automatizada e documentação interativa.

---

## 🌟 Conceitos e Diferenciais Destacados

- **Autenticação & Autorização:** Proteção de endpoints utilizando **JWT (JSON Web Tokens)** para simular arquiteturas reais de nuvem e Identity APIs.
- **Testes Automatizados:** Cobertura de regras de negócio complexas utilizando **xUnit** para a estrutura de testes e **FluentAssertions** para escritas legíveis e fluidas.
- **Princípios de Arquitetura Limpa:** Total isolamento entre regras de domínio (cálculo de quilometragem e taxas) e a camada de exposição de API.
- **Documentação Interativa:** Integração nativa com **Swagger** para fornecer uma interface clara de experimentação dos endpoints.

---

## ⚙️ Regras de Negócio e Endpoints

1. **`POST /api/Auth/login`**: Endpoint público de autenticação. Use as credenciais para obter o Token JWT válido:
   ```json
   {
     "username": "admin",
     "password": "password123"
   }

2- POST /api/Freight/calculate: Endpoint protegido (requer Token Bearer no Header).

Preço Base: R$ 2,50 por Km rodado.

Taxa de Longa Distância: Acréscimo fixo de R$ 100,00 para rotas acima de 500 Km de distância total.

🛠️ Como Executar o Projeto pelo GitHub Codespaces
Na página deste repositório, clique em Code -> Codespaces -> Create codespace on main.

No terminal do seu Codespaces, execute o comando para iniciar a API:

dotnet run --project FreightManagement.Api/FreightManagement.Api.csproj

3- Clique na notificação que surgir no navegador para abrir o link da aplicação.

4- Adicione /swagger/index.html ao fim da URL gerada para interagir com a interface.

Para rodar a suíte de testes unitários do projeto, execute:

dotnet test

## 🧪 Demonstração dos Testes (Postman)

Para validar a segurança da API e as regras de negócio, os testes foram realizados localmente. Clique nos títulos abaixo para visualizar as evidências:

<details>
  <summary>🔑 Clique para ver o teste de Autenticação (JWT)</summary>
  <br>
  <p>Envio das credenciais para o endpoint <code>/api/Auth/login</code> para receber o token de acesso seguro.</p>
  <img src="../docs/login-teste.JPG" alt="Teste de Autenticação" width="100%">
</details>

<details>
  <summary>🚚 Clique para ver o teste de Cálculo de Frete (Status 200 OK)</summary>
  <br>
  <p>Envio dos dados de distância, peso e rota para o endpoint <code>/api/Freight/calculate</code> com o token ativo.</p>
  <img src="../docs/calculo-frete-teste.JPG" alt="Teste de Cálculo de Frete" width="100%">
</details>

<details>
  <summary>🚚 Clique para ver os resultados dos testes</summary>
  <br>
  <img src=".teste-passou.JPG" alt="Teste de Cálculo de Frete" width="100%">
</details>
