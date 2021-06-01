import React from 'react';
import './App.css';

//Cria/Define uma função chamada DataFormatada que retorna o subtítulo com o valor da data formatada
function DataFormatada(props) 
{
  return <h2> Horário Atual: {props.date.toLocaleTimeString()}</h2>  
}

//Define a classe Clock que será chamada na renderização dentro do APP
class Relogio extends React.Component
{
  constructor(props){
    super(props);

    this.state = {
      //Define o estado date pegando a data/hora atual
      date : new Date()
    };
  }

  //Função pré-estabelecidade
  //Ciclo de vida que ocorre quando Relogio é inserido na DOM
  componentDidMount(){
    //Através da setInterval o relógio e criado(com um timerID atrelado)
    this.timerId = setInterval( () => {
      //Chama a função ticTak() a cada 1000ms (1s)
      this.tictak()
    }, 1000 );
  }

  //Função pré-estabelecidade
  //Ciclo de vida que ocorre quando Relogio é removido na DOM
  componentWillUnmount(){
    //Quando isso ocorre, a função clearInterval limpa o relógio criado pelo setInterval
    clearInterval(this.timerId);
  }

  pausar(){
    //Limpa o relógio criado
    clearInterval(this.timerId);
    //Mostra no console a mensagem
    console.log(`O relógio ${this.timerId} foi pausado!`);
  }

  retomar(){
    //Chama o setInterval com uma arrow function, e dentro dela chama a função que atualiza o relógio, sendo o tempo de atualização de 1000ms (1s)
    this.timerId = setInterval( () => {
      this.tictak()
    }, 1000)
    //Mostra uma mensagem
    console.log(`Relógio retomado`);
    //Diz que foi criado outro relógio para voltar a rodar
    console.log(`Agora sou o relógio ${this.timerId}`);
  }

  //Sobreescreve no state dae a data atual a cada vez que é chamada
  tictak(){
    this.setState({
      date : new Date() // = DateTime.Now on c#
    });
  }
  
  //Renderiza na tela o título
  render(){
    return(
      <div>
        <h1>Relógio do brabo</h1>
        <DataFormatada date={this.state.date} />
        {/* Cria um botão que, ao clicar, executa a função pausar, criada um pouco acima */}
        <button style={{backgroundColor : "Red", fontSize : "25px", margin : "20px"}} onClick={() => this.pausar()}>Pausar</button>
        <button style={{backgroundColor : "Green", fontSize : "25px", margin : "20px"}} onClick={() => this.retomar()}>Retomar</button>
      </div>
    )
  }
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
      {/* Chama dois relógios para mostrar a indepêndencia deles  */}
      <Relogio />
      <Relogio />
      </header>
    </div>
  );
}

//Declara que a função App pode ser usada fora do escopo dela mesma
export default App;
