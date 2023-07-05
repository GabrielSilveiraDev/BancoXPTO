using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoBancoFinal.Areas.Identity.Data;
using ProjetoBancoFinal.Models;
using ProjetoBancoFinal.Repositories;
using ProjetoBancoFinal.ViewModels;

namespace ProjetoBancoFinal.Controllers
{
    [Authorize]
    public class ContaController : Controller
    {
        private UserManager<Cliente> _userManager;
        private IClienteRepository _clienteRepository;
        private IChavePixRepository _chavePixRepository;
        private IContaRepository _contaRepository;
        private Cliente ClienteLogado()
        {
            return _clienteRepository.BuscarPorId(_userManager.GetUserId(User));
        }

        public ContaController(UserManager<Cliente> userManager, IClienteRepository clienteRepository, IChavePixRepository chavePixRepository, IContaRepository contaRepository)
        {
            _userManager = userManager;
            _clienteRepository = clienteRepository;
            _chavePixRepository = chavePixRepository;
            _contaRepository = contaRepository;
        }


        public IActionResult Index()
        {
            Cliente cliente = ClienteLogado();
            cliente.ValidarTipo();
            ClienteChavePixViewModel viewModel = new ClienteChavePixViewModel()
            {
                Cliente = cliente
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Transferir(decimal valor, string chave, TipoChavePix tipoChave)
        {
            Cliente cliente = ClienteLogado();

            if (cliente.Conta.Saldo < valor)
            {
                ModelState.AddModelError("Valor", "Valor inválido");
                TempData["saldoNeg"] = "Saldo insuficiente";
                return RedirectToAction("Index");
            }
            if (valor <= 0)
            {
                ModelState.AddModelError("Valor", "Valor inválido");
                TempData["saldoNeg"] = "Valor de transferência inválido";
                return RedirectToAction("Index");
            }

            ChavePix chaveTransferencia = _chavePixRepository.BuscarPor(cv => cv.Chave == chave && cv.Tipo == tipoChave).FirstOrDefault();

            if (chaveTransferencia == null)
            {
                ModelState.AddModelError("Chave", "Chave inválida");
                TempData["saldoNeg"] = "Chave PIX inválida";
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                Conta contaAlvo = _contaRepository.BuscarPorId(chaveTransferencia.ContaId);

                if (contaAlvo == cliente.Conta)
                {
                    TempData["erroTransferir"] = "Não é possível transferir para si mesmo.";
                }
                else
                {
                    cliente.Conta.Transferir(valor);
                    contaAlvo.Depositar(valor);
                    _clienteRepository.Atualizar(cliente);
                    _contaRepository.Atualizar(contaAlvo);
                    _clienteRepository.Salvar();
                    TempData["msg"] = "Valor transferido com sucesso para " + _clienteRepository.BuscarPorConta(contaAlvo).Nome;
                }

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                ModelState.AddModelError("Valor", "Valor inválido");
                TempData["valorNeg"] = "Valor inválido";
            }

            if (ModelState.IsValid)
            {
                Cliente cliente = ClienteLogado();
                cliente.Conta.Depositar(valor);
                _clienteRepository.Atualizar(cliente);
                _clienteRepository.Salvar();
                TempData["msg"] = "Valor depositado com sucesso";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult CadastrarChavePix(string? chave, TipoChavePix tipoChave)
        {

            if ((tipoChave == TipoChavePix.Email || tipoChave == TipoChavePix.Telefone) && String.IsNullOrEmpty(chave))
            {
                ModelState.AddModelError("Chave", "Digite um chave PIX");
                TempData["cvInvalida"] = "Digite uma chave PIX para cadastrar";
            }

            Cliente cliente = ClienteLogado();
            if (tipoChave == TipoChavePix.Cpf)
                chave = cliente.Cpf;
            if (_chavePixRepository.BuscarPor(c => (c.Chave == chave) && (c.Tipo == tipoChave)).Count > 0)
            {
                ModelState.AddModelError("Chave", "Chave já cadastrada");
                TempData["cvInvalida"] = "Chave já cadastrada";
            }            

            if (ModelState.IsValid)
            {
                
                if (tipoChave == TipoChavePix.Aleatorio)
                {
                    do
                    {
                        chave = Guid.NewGuid().ToString();
                    }
                    while (_chavePixRepository.BuscarPor(c => (c.Chave == chave) && (c.Tipo == tipoChave)).Count > 0);
                }

                ChavePix chavePix = new ChavePix();
                chavePix.Tipo = tipoChave;
                chavePix.Conta = cliente.Conta;
                chavePix.Chave = chave;

                _chavePixRepository.Cadastrar(chavePix);
                _chavePixRepository.Salvar();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoverChavePix(int id)
        {
            _chavePixRepository.Remover(id);
            _chavePixRepository.Salvar();
            TempData["rmvCv"] = "Chave PIX removida com sucesso";
            return RedirectToAction("Index");
        }

    }
}
