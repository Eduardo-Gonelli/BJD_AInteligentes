using System.Collections.Generic;
using UnityEngine;

namespace ExemploAspirador
{
    /// <summary>
    /// Implementa um agente aspirador de pó que reage a percepções simples.
    /// </summary>
    public class TableDrivenAgent : MonoBehaviour
    {
        // Sequência de percepções representada como string
        private List<string> perceptions = new List<string>();

        // Tabela de ações
        private Dictionary<string, System.Action> actionTable = new Dictionary<string, System.Action>();

        // Game Manager
        public GameManager gameManager;

        void Start()
        {
            // Inicializa a tabela de ações baseadas nas percepções
            actionTable.Add("Sujo", Limpar);
            actionTable.Add("Limpo", Mover);
        }

        /// <summary>
        /// Processa a percepção recebida e determina a ação correspondente.
        /// </summary>
        /// <param name="perception">A percepção atual do agente.</param>
        public void Perceive(string perception)
        {
            // Adiciona a percepção na lista de percepções
            perceptions.Add(perception);

            // Cria uma chave única para a sequência de percepções
            string perceptionsKey = string.Join("\n", perceptions);

            // Acessa a ação baseada nas percepções acumuladas
            if (actionTable.TryGetValue(perception, out System.Action action))
            {
                // Executa a ação correspondente
                action.Invoke();
                gameManager.SetPerception(perceptionsKey);
            }
            else
            {
                // Lida com percepções não mapeadas ou sequências inválidas
                gameManager.SetPerception("Percepção não mapeada: " + perception);
                // Se tentar executar uma ação que não existe, exibe uma mensagem de erro
                // No exemplo, não existe uma ação mapeada para o botão "Molhado"
                Debug.LogError("Percepção não mapeada: " + perception);
            }            
        }

        #region Ações

        /// <summary>
        /// Limpa o ambiente
        /// </summary>
        private void Limpar()
        {            
            gameManager.SetAction("Limpar");
        }


        /// <summary>
        /// Move o agente para uma nova posição
        /// </summary>
        private void Mover()
        {            
            gameManager.SetAction("Mover");
        }

        #endregion
    }
}


