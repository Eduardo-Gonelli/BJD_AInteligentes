using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExemploAspirador
{
    /// <summary>
    /// Implementa um agente aspirador de p� que reage a percep��es simples.
    /// </summary>
    public class TableDrivenAgent : MonoBehaviour
    {
        // Sequ�ncia de percep��es representada como string
        private List<string> perceptions = new List<string>();

        // Tabela de a��es
        private Dictionary<string, System.Action> actionTable = new Dictionary<string, System.Action>();

        // Game Manager
        public GameManager gameManager;

        void Start()
        {
            // Inicializa a tabela de a��es baseadas nas percep��es
            actionTable.Add("Sujo", Limpar);
            actionTable.Add("Limpo", Mover);
        }

        /// <summary>
        /// Processa a percep��o recebida e determina a a��o correspondente.
        /// </summary>
        /// <param name="perception">A percep��o atual do agente.</param>
        public void Perceive(string perception)
        {
            // Adiciona a percep��o na lista de percep��es
            perceptions.Add(perception);

            // Cria uma chave �nica para a sequ�ncia de percep��es
            string perceptionsKey = string.Join("\n", perceptions);

            // Acessa a a��o baseada nas percep��es acumuladas
            if (actionTable.TryGetValue(perception, out System.Action action))
            {
                // Executa a a��o correspondente
                action.Invoke();
                gameManager.SetPerception(perceptionsKey);
            }
            else
            {
                // Lida com percep��es n�o mapeadas ou sequ�ncias inv�lidas
                gameManager.SetPerception("Percep��o n�o mapeada: " + perception);
                // Se tentar executar uma a��o que n�o existe, exibe uma mensagem de erro
                // No exemplo, n�o existe uma a��o mapeada para o bot�o "Molhado"
                Debug.LogError("Percep��o n�o mapeada: " + perception);
            }            
        }

        #region A��es

        /// <summary>
        /// Limpa o ambiente
        /// </summary>
        private void Limpar()
        {            
            gameManager.SetAction("Limpar");
        }


        /// <summary>
        /// Move o agente para uma nova posi��o
        /// </summary>
        private void Mover()
        {            
            gameManager.SetAction("Mover");
        }

        #endregion
    }
}


