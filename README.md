# 🍔 Divinos Burguer

Este projeto é um **exemplo funcional** de implantação do **[Plugin.Firebase]([https://github.com/f-miyu/Plugin.Firebase](https://www.nuget.org/packages/Plugin.Firebase)** em um app .NET MAUI, compatível com **Android** e **iOS**.  

⚠️ **Atenção**: este projeto não está completo, ele serve como **base de estudo e referência** para a configuração do Firebase em projetos reais.

---

## 📌 Como usar este projeto

1. **Clone o repositório**  
   ```bash
   git clone
   ```

2. **Adicione suas credenciais Firebase**  
   - No projeto, procure **exatamente** por:
     ```
     "***"
     ```
     e substitua pelos seus valores de configuração.

3. **Substitua os arquivos de configuração**  
   - Substitua os seguintes arquivos pelos que você baixou do console do Firebase:
     - `GoogleService-Info.plist` (iOS)  
     - `google-services.json` (Android)  

   ⚠️ **Importante**: ao substituir, verifique se o arquivo `.csproj` não sofreu alterações indevidas, pois isso pode comprometer a build.

---

## 🚀 Funcionalidades já implementadas
- Estrutura base de integração com o **Firebase**.  
- Suporte a **Android** e **iOS**.  
- Projeto pronto para receber suas credenciais e rodar.  

---

## 📱 Requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (com workload **MAUI**)  
- Conta no [Firebase Console](https://console.firebase.google.com/)

---

## ⚠️ Observações
- Este projeto é **incompleto**, foi feito apenas como **exemplo de implantação**.  
- Para produção, recomenda-se implementar regras de segurança, tratamento de erros e demais serviços do Firebase.  

---

## 📝 Licença
Este projeto é apenas um **exemplo educacional**. Use-o como referência para seus próprios projetos.  
