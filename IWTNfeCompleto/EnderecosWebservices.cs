using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace IWTNFCompleto
{
    internal enum ServicoNFe
    {
        NfeRecepcao,
        NfeRetRecepcao,
        NfeCancelamento,
        NfeInutilizacao,
        NfeConsultaProtocolo,
        NfeStatusServico,
        NfeConsultaCadastro,
        RecepcaoEvento
    }

    internal static class EnderecosWebservices
    {
        private static Dictionary<EnderecoWebserviceKey, string> _enderecos;

        private static Dictionary<EnderecoWebserviceKey, string> _enderecosSvc;

        private static Semaphore _semaphore = new Semaphore(1, 1);

        private static void LoadDados()
        {
            _enderecos = new Dictionary<EnderecoWebserviceKey, string>();
            _enderecosSvc = new Dictionary<EnderecoWebserviceKey, string>();

            #region Sefaz Virtual Ambiente Nacional - (SVAN)

            const string SVANNfeRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NFeAutorizacao4/NFeAutorizacao4.asmx";
            const string SVANNfeRetRecepcao = "https://www.sefazvirtual.fazenda.gov.br/NFeRetAutorizacao4/NFeRetAutorizacao4.asmx";
            const string SVANNfeInutilizacao = "https://www.sefazvirtual.fazenda.gov.br/NFeInutilizacao4/NFeInutilizacao4.asmx";
            const string SVANNfeConsultaProtocolo = "https://www.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
            const string SVANNfeStatusServico = "https://www.sefazvirtual.fazenda.gov.br/NFeStatusServico4/NFeStatusServico4.asmx";
            const string SVANRecepcaoEvento = "https://www.sefazvirtual.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx";

            const string SVANNfeRecepcaoHomologacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeAutorizacao4/NFeAutorizacao4.asmx";
            const string SVANNfeRetRecepcaoHomologacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeRetAutorizacao4/NFeRetAutorizacao4.asmx";
            const string SVANNfeInutilizacaoHomologacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeInutilizacao4/NFeInutilizacao4.asmx";
            const string SVANNfeConsultaProtocoloHomologacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
            const string SVANNfeStatusServicoHomologacao = "https://hom.sefazvirtual.fazenda.gov.br/NFeStatusServico4/NFeStatusServico4.asmx";
            const string SVANRecepcaoEventoHomologacao = "	https://hom.sefazvirtual.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx";

            #endregion

            #region Sefaz Virtual Rio Grande do Sul - (SVRS)

            const string SVRSNfeRecepcao = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx";
            const string SVRSNfeRetRecepcao = "https://nfe.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao4.asmx";
            const string SVRSNfeInutilizacao = "https://nfe.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx";
            const string SVRSNfeConsultaProtocolo = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
            const string SVRSNfeStatusServico = "https://nfe.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx";
            const string SVRSRecepcaoEvento = "	https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx";

            const string SVRSNfeRecepcaoHomologacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx";
            const string SVRSNfeRetRecepcaoHomologacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao4.asmx";
            const string SVRSNfeInutilizacaoHomologacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx";
            const string SVRSNfeConsultaProtocoloHomologacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
            const string SVRSNfeStatusServicoHomologacao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx";
            const string SVRSRecepcaoEventoHomologacao = "	https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx";

            #endregion

            #region SVC

            const string SVCANProducaoRecepcaoEvento = "https://www.svc.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx";
            const string SVCANProducaoRecepcao = "https://www.svc.fazenda.gov.br/NFeAutorizacao4/NFeAutorizacao4.asmx";
            const string SVCANProducaoRetRecepcao = "https://www.svc.fazenda.gov.br/NFeRetAutorizacao4/NFeRetAutorizacao4.asmx";
            const string SVCANProducaoConsultaProtocolo = "https://www.svc.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
            const string SVCANProducaoStatusServico = "https://www.svc.fazenda.gov.br/NFeStatusServico4/NFeStatusServico4.asmx";

            const string SVCRSProducaoRecepcaoEvento = "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx";
            const string SVCRSProducaoRecepcao = "https://nfe.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx";
            const string SVCRSProducaoRetRecepcao = "https://nfe.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao4.asmx";
            const string SVCRSProducaoConsultaProtocolo = "https://nfe.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
            const string SVCRSProducaoStatusServico = "	https://nfe.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx";



            const string SVCANHomologacaoRecepcaoEvento = "https://hom.svc.fazenda.gov.br/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx";
            const string SVCANHomologacaoRecepcao = "https://hom.svc.fazenda.gov.br/NFeAutorizacao4/NFeAutorizacao4.asmx";
            const string SVCANHomologacaoRetRecepcao = "https://hom.svc.fazenda.gov.br/NFeRetAutorizacao4/NFeRetAutorizacao4.asmx";
            const string SVCANHomologacaoConsultaProtocolo = "https://hom.svc.fazenda.gov.br/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx";
            const string SVCANHomologacaoStatusServico = "https://hom.svc.fazenda.gov.br/NFeStatusServico4/NFeStatusServico4.asmx";

            const string SVCRSHomologacaoRecepcaoEvento = "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx";
            const string SVCRSHomologacaoRecepcao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx";
            const string SVCRSHomologacaoRetRecepcao = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao4.asmx";
            const string SVCRSHomologacaoConsultaProtocolo = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx";
            const string SVCRSHomologacaoStatusServico = "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx";


            #endregion

            #region Estados que Usam SVC - AN



            #region AC

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region AL

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region AP

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region DF

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region ES

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region MG

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MG, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region PB

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region PI

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region RJ

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region RN

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region RS

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RS, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region RO

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region RR

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region SC

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region SE

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region SP

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SP, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion

            #region TO

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANHomologacaoStatusServico);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVCANProducaoRecepcaoEvento);

            #endregion



            #endregion

            #region Estados que Usam SVC - RS

            #region AM

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AM, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region BA

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.BA, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region CE

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.CE, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region GO

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.GO, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region MA

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region MT

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MT, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region MS

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MS, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region PA

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region PE

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PE, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion

            #region PR

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSHomologacaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSHomologacaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSHomologacaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSHomologacaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSHomologacaoRecepcaoEvento);

            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSProducaoRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSProducaoRetRecepcao);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSProducaoConsultaProtocolo);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSProducaoStatusServico);
            _enderecosSvc.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PR, "4.00", TMod.Item55), SVCRSProducaoRecepcaoEvento);

            #endregion
            #endregion

            #region Estados que usam a SVAN

            #region Maranhão

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MA, "4.00", TMod.Item55), SVANRecepcaoEventoHomologacao);

            #endregion

            #region Pará

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PA, "4.00", TMod.Item55), SVANRecepcaoEventoHomologacao);

            #endregion

            #endregion

            #region Estados que usam a SVRS

            #region AC

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AC, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region AL

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AL, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region Amapá

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AP, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region Distrito Federal

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.DF, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region Espirito Santo

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.ES, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region Paraíba

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PB, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region PI

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PI, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region Rio de Janeiro

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RJ, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region Rio Grande do Norte

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RN, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region RR

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RR, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region RO

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RO, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region Santa Catarina

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SC, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region SE

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SE, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

            #region TO

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeRetRecepcao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeInutilizacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeConsultaProtocolo);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeStatusServico);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSRecepcaoEvento);

            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeRetRecepcaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeInutilizacaoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeConsultaProtocoloHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSNfeStatusServicoHomologacao);
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.TO, "4.00", TMod.Item55), SVRSRecepcaoEventoHomologacao);

            #endregion

   

       

          
            #endregion
          
            #region UFs Com autorização Própria - Produção

            #region NFeV4
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://nfe.sefaz.am.gov.br/services2/services/NfeInutilizacao4                                  ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://nfe.sefaz.am.gov.br/services2/services/NfeConsulta4                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://nfe.sefaz.am.gov.br/services2/services/NfeStatusServico4                                 ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://nfe.sefaz.am.gov.br/services2/services/RecepcaoEvento4                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://nfe.sefaz.am.gov.br/services2/services/NfeAutorizacao4                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://nfe.sefaz.am.gov.br/services2/services/NfeRetAutorizacao4                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://nfe.sefaz.ba.gov.br/webservices/NFeInutilizacao4/NFeInutilizacao4.asmx                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://nfe.sefaz.ba.gov.br/webservices/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://nfe.sefaz.ba.gov.br/webservices/NFeStatusServico4/NFeStatusServico4.asmx                 ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://nfe.sefaz.ba.gov.br/webservices/CadConsultaCadastro4/CadConsultaCadastro4.asmx           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://nfe.sefaz.ba.gov.br/webservices/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx               ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://nfe.sefaz.ba.gov.br/webservices/NFeAutorizacao4/NFeAutorizacao4.asmx                     ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://nfe.sefaz.ba.gov.br/webservices/NFeRetAutorizacao4/NFeRetAutorizacao4.asmx	              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeInutilizacao4?wsdl                                  ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeConsultaProtocolo4?wsdl                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeStatusServico4?wsdl                                 ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfe.sefaz.ce.gov.br/nfe4/services/CadConsultaCadastro4?wsdl                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeRecepcaoEvento4?wsdl                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeAutorizacao4?wsdl                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfe.sefaz.ce.gov.br/nfe4/services/NFeRetAutorizacao4?wsdl                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://nfe.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://nfe.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://nfe.sefaz.go.gov.br/nfe/services/NFeStatusServico4?wsdl                                  ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://nfe.sefaz.go.gov.br/nfe/services/CadConsultaCadastro4?wsdl                               ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://nfe.sefaz.go.gov.br/nfe/services/NFeRecepcaoEvento4?wsdl                                 ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://nfe.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl                                    ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://nfe.sefaz.go.gov.br/nfe/services/NFeRetAutorizacao4?wsdl	                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4                                     ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4                                    ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://nfe.fazenda.mg.gov.br/nfe2/services/NFeRetAutorizacao4	                                  ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://nfe.fazenda.ms.gov.br/ws/NFeInutilizacao4                                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://nfe.fazenda.ms.gov.br/ws/NFeConsultaProtocolo4                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://nfe.fazenda.ms.gov.br/ws/NFeStatusServico4                                               ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://nfe.fazenda.ms.gov.br/ws/CadConsultaCadastro4                                            ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://nfe.fazenda.ms.gov.br/ws/NFeRecepcaoEvento4                                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://nfe.fazenda.ms.gov.br/ws/NFeAutorizacao4                                                 ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://nfe.fazenda.ms.gov.br/ws/NFeRetAutorizacao4	                                            ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeInutilizacao4?wsdl                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl                                  ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeStatusServico4?wsdl                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://nfe.sefaz.mt.gov.br/nfews/v2/services/CadConsultaCadastro4?wsdl                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://nfe.sefaz.mt.gov.br/nfews/v2/services/RecepcaoEvento4?wsdl                               ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeAutorizacao4?wsdl                               ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://nfe.sefaz.mt.gov.br/nfews/v2/services/NfeRetAutorizacao4?wsdl	                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeInutilizacao4                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeStatusServico4                               ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeRecepcaoEvento4                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeAutorizacao4                                 ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfe.sefaz.pe.gov.br/nfe-service/services/NFeRetAutorizacao4	                            ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://nfe.sefa.pr.gov.br/nfe/NFeInutilizacao4?wsdl                                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://nfe.sefa.pr.gov.br/nfe/NFeStatusServico4?wsdl                                            ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://nfe.sefa.pr.gov.br/nfe/CadConsultaCadastro4?wsdl                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://nfe.sefa.pr.gov.br/nfe/NFeRecepcaoEvento4?wsdl                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://nfe.sefa.pr.gov.br/nfe/NFeAutorizacao4?wsdl                                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://nfe.sefa.pr.gov.br/nfe/NFeRetAutorizacao4?wsdl	                                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://cad.sefazrs.rs.gov.br/ws/cadconsultacadastro/cadconsultacadastro4.asmx                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe.sefazrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao4.asmx	                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://nfe.fazenda.sp.gov.br/ws/nfestatusservico4.asmx                                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx                                       ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://nfe.fazenda.sp.gov.br/ws/nferecepcaoevento4.asmx                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx                                            ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://nfe.fazenda.sp.gov.br/ws/nferetautorizacao4.asmx	                                        ".Trim());





            #endregion


            #endregion


            #region Estados com Autorização Própria - Homologação


            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://homnfe.sefaz.am.gov.br/services2/services/NfeInutilizacao4                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://homnfe.sefaz.am.gov.br/services2/services/NfeConsulta4                                            ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://homnfe.sefaz.am.gov.br/services2/services/NfeStatusServico4                                       ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://homnfe.sefaz.am.gov.br/services2/services/RecepcaoEvento4                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://homnfe.sefaz.am.gov.br/services2/services/NfeAutorizacao4                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.AM, "4.00", TMod.Item55), "https://homnfe.sefaz.am.gov.br/services2/services/NfeRetAutorizacao4                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://hnfe.sefaz.ba.gov.br/webservices/NFeInutilizacao4/NFeInutilizacao4.asmx                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://hnfe.sefaz.ba.gov.br/webservices/NFeConsultaProtocolo4/NFeConsultaProtocolo4.asmx                 ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://hnfe.sefaz.ba.gov.br/webservices/NFeStatusServico4/NFeStatusServico4.asmx                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://hnfe.sefaz.ba.gov.br/webservices/CadConsultaCadastro4/CadConsultaCadastro4.asmx                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://hnfe.sefaz.ba.gov.br/webservices/NFeRecepcaoEvento4/NFeRecepcaoEvento4.asmx                       ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://hnfe.sefaz.ba.gov.br/webservices/NFeAutorizacao4/NFeAutorizacao4.asmx                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.BA, "4.00", TMod.Item55), "https://hnfe.sefaz.ba.gov.br/webservices/NFeRetAutorizacao4/NFeRetAutorizacao4.asmx                       ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfeh.sefaz.ce.gov.br/nfe4/services/NFeInutilizacao4?WSDL                                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfeh.sefaz.ce.gov.br/nfe4/services/NFeConsultaProtocolo4?WSDL                                     ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfeh.sefaz.ce.gov.br/nfe4/services/NFeStatusServico4?WSDL                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfeh.sefaz.ce.gov.br/nfe4/services/NFeRecepcaoEvento4?WSDL                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfeh.sefaz.ce.gov.br/nfe4/services/NFeAutorizacao4?WSDL                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.CE, "4.00", TMod.Item55), "https://nfeh.sefaz.ce.gov.br/nfe4/services/NFeRetAutorizacao4?WSDL                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://homolog.sefaz.go.gov.br/nfe/services/NFeInutilizacao4?wsdl                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://homolog.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4?wsdl                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://homolog.sefaz.go.gov.br/nfe/services/NFeStatusServico4?wsdl                                       ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://homolog.sefaz.go.gov.br/nfe/services/CadConsultaCadastro4?wsdl                                    ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://homolog.sefaz.go.gov.br/nfe/services/NFeRecepcaoEvento4?wsdl                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://homolog.sefaz.go.gov.br/nfe/services/NFeAutorizacao4?wsdl                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.GO, "4.00", TMod.Item55), "https://homolog.sefaz.go.gov.br/nfe/services/NFeRetAutorizacao4?wsdl                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeInutilizacao4                                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeConsultaProtocolo4                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeStatusServico4                                            ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeRecepcaoEvento4                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeAutorizacao4                                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MG, "4.00", TMod.Item55), "https://hnfe.fazenda.mg.gov.br/nfe2/services/NFeRetAutorizacao4                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://hom.nfe.sefaz.ms.gov.br/ws/NFeInutilizacao4                                                       ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://hom.nfe.sefaz.ms.gov.br/ws/NFeConsultaProtocolo4                                                  ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://hom.nfe.sefaz.ms.gov.br/ws/NFeStatusServico4                                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://hom.nfe.sefaz.ms.gov.br/ws/CadConsultaCadastro4                                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://hom.nfe.sefaz.ms.gov.br/ws/NFeRecepcaoEvento4                                                     ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://hom.nfe.sefaz.ms.gov.br/ws/NFeAutorizacao4                                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MS, "4.00", TMod.Item55), "https://hom.nfe.sefaz.ms.gov.br/ws/NFeRetAutorizacao4                                                     ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeInutilizacao4?wsdl                               ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeConsulta4?wsdl                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeStatusServico4?wsdl                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/CadConsultaCadastro4?wsdl                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/RecepcaoEvento4?wsdl                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeAutorizacao4?wsdl                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.MT, "4.00", TMod.Item55), "https://homologacao.sefaz.mt.gov.br/nfews/v2/services/NfeRetAutorizacao4?wsdl                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeInutilizacao4                                  ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeConsultaProtocolo4                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeStatusServico4                                 ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeRecepcaoEvento4                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeAutorizacao4                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item55), "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeRetAutorizacao4                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeInutilizacao4?wsdl                                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl                                     ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeStatusServico4?wsdl                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://homologacao.nfe.sefa.pr.gov.br/nfe/CadConsultaCadastro4?wsdl                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeRecepcaoEvento4?wsdl                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeAutorizacao4?wsdl                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item55), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeRetAutorizacao4?wsdl                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe-homologacao.sefazrs.rs.gov.br/ws/nfeinutilizacao/nfeinutilizacao4.asmx                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeConsulta/NfeConsulta4.asmx                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe-homologacao.sefazrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao4.asmx                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.RS, "4.00", TMod.Item55), "https://nfe-homologacao.sefazrs.rs.gov.br/ws/NfeRetAutorizacao/NFeRetAutorizacao4.asmx                    ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeinutilizacao4.asmx                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeconsultaprotocolo4.asmx                                   ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfestatusservico4.asmx                                       ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://homologacao.nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx                                    ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://homologacao.nfe.fazenda.sp.gov.br/ws/nferecepcaoevento4.asmx                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeautorizacao4.asmx                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.SP, "4.00", TMod.Item55), "https://homologacao.nfe.fazenda.sp.gov.br/ws/nferetautorizacao4.asmx                                      ".Trim());


            #endregion





            #region NFCe

            // --- AMBIENTE DE HOMOLOGAÇÃO ---
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PE, "4.00", TMod.Item65), "https://nfehomolog.sefaz.pe.gov.br/nfe-service/services/NFeRetAutorizacao4                                ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeInutilizacao4?wsdl                                          ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl                                     ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeStatusServico4?wsdl                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://homologacao.nfe.sefa.pr.gov.br/nfe/CadConsultaCadastro4?wsdl                                      ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeRecepcaoEvento4?wsdl                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeAutorizacao4?wsdl                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Homologacao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://homologacao.nfe.sefa.pr.gov.br/nfe/NFeRetAutorizacao4?wsdl                                        ".Trim());

            // --- AMBIENTE DE PRODUÇÃO ---
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeInutilizacao, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://nfe.sefa.pr.gov.br/nfe/NFeInutilizacao4?wsdl                                             ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaProtocolo, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://nfe.sefa.pr.gov.br/nfe/NFeConsultaProtocolo4?wsdl                                        ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeStatusServico, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://nfe.sefa.pr.gov.br/nfe/NFeStatusServico4?wsdl                                            ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeConsultaCadastro, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://nfe.sefa.pr.gov.br/nfe/CadConsultaCadastro4?wsdl                                         ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.RecepcaoEvento, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://nfe.sefa.pr.gov.br/nfe/NFeRecepcaoEvento4?wsdl                                           ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://nfe.sefa.pr.gov.br/nfe/NFeAutorizacao4?wsdl                                              ".Trim());
            _enderecos.Add(new EnderecoWebserviceKey(TAmbLegado.Producao, ServicoNFe.NfeRetRecepcao, TCodUfIBGELegado.PR, "4.00", TMod.Item65), "https://nfe.sefa.pr.gov.br/nfe/NFeRetAutorizacao4?wsdl	                                          ".Trim());


            #endregion

        }


        internal static string GetEndereco(TCodUfIBGELegado uf, string versao, TAmbLegado ambiente, ServicoNFe servico, bool Scan, TMod mod)
        {
            try
            {
                _semaphore.WaitOne();

                if (_enderecos == null)
                {
                    LoadDados();
                }

                AjustaTlsClass.Ajustar(uf);

                EnderecoWebserviceKey tmpKey = new EnderecoWebserviceKey(ambiente, servico, uf, versao, mod);

                if (mod == TMod.Item55)
                {
                    if (Scan)
                    {
                        if (_enderecosSvc != null && _enderecosSvc.ContainsKey(tmpKey))
                        {
                            return _enderecosSvc[tmpKey].Trim();
                        }
                        else
                        {
                            throw new Exception("O serviço solicitado não está diponivel para o estado selecionado no ambiente de contingência");
                        }

                    }
                    else
                    {


                        if (_enderecos != null && _enderecos.ContainsKey(tmpKey))
                        {
                            return _enderecos[tmpKey].Trim();
                        }
                        else
                        {
                            throw new Exception("O serviço solicitado não está diponivel para o estado selecionado");
                        }
                    }
                }
                else
                {
                    if (mod == TMod.Item65)
                    {
                        if (_enderecos != null && _enderecos.ContainsKey(tmpKey))
                        {
                            return _enderecos[tmpKey].Trim();
                        }
                        else
                        {
                            throw new Exception("O serviço solicitado não está diponivel para o estado selecionado");
                        }
                    }
                    else
                    {
                        throw new Exception("Modelo de documento Inválido");
                    }
                }
              
            }
            finally
            {
                _semaphore.Release();
            }
        }
        
    }

   

    class EnderecoWebserviceKey : IEquatable<EnderecoWebserviceKey>
    {
        public TCodUfIBGELegado Uf { get; private set; }
        public string Versao { get; private set; }
        public TMod Modelo { get; private set; }
        public TAmbLegado Ambiente { get; private set; }
        public ServicoNFe Servico { get; private set; }

        public EnderecoWebserviceKey(TAmbLegado ambiente, ServicoNFe servico, TCodUfIBGELegado uf, string versao, TMod modelo)
        {
            Ambiente = ambiente;
            Servico = servico;
            Uf = uf;
            Versao = versao;
            Modelo = modelo;
        }

        public bool Equals(EnderecoWebserviceKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Uf == other.Uf && string.Equals(Versao, other.Versao) && Modelo == other.Modelo && Ambiente == other.Ambiente && Servico == other.Servico;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EnderecoWebserviceKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Uf;
                hashCode = (hashCode*397) ^ (Versao != null ? Versao.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) Modelo;
                hashCode = (hashCode*397) ^ (int) Ambiente;
                hashCode = (hashCode*397) ^ (int) Servico;
                return hashCode;
            }
        }
    }
}
