import React, { Component } from 'react';

var time = 1
var cnt = 1
class App extends Component {
  constructor(props){
    super(props)
    this.state = {
      servers: [
        {state: 1, time: 0, cur: 0},
        {state: 1, time: 0, cur: 0},
        {state: 1, time: 0, cur: 0},
      ],
      serversWorks: [0, 1, 2],
      queue: [[], [], []],
      avgCalls: 0,
      calls: 0,
      lyambdaTime: 0,
      lyambda: 0,
      wait: 0,
      th: 0,
      avgTh: 0,
      avgWaitingTime: 0,
      lastTime: 0,
    }
  }

  componentWillMount(){
    setInterval(() =>{
      var call = Math.floor(Math.random() * 2)
      if(call == 1){
        var num = this.state.calls
        num++;
        var ltime = this.state.lyambdaTime
        ltime += time - this.state.lastTime
        var lyambda = ltime/num
        var p = Math.floor(Math.random() * 3)
        var q = 10000000, ix = -1
        this.state.serversWorks.map((s, i) => {
          if(s == p){
            if(this.state.queue[i].length < q){
              q = this.state.queue[i].length
              ix = i
            }
          }
        })
        if(ix != -1){
          var curQueue =  this.state.queue
          curQueue[ix].push({time: time+600, was: 0});
          this.setState({
            calls: num,
            queue: curQueue,
            avgCalls: num/time,
            lyambda: lyambda,
            lastTime: time,
          })
        }
      }
      time += 200;
    } , 200)

    setInterval(() => {
      var curSt = this.state.servers
      var curQueue = this.state.queue
      var W = this.state.wait
      var calls = this.state.calls
      var th = this.state.th
      var avgTh = this.state.avgTh
      if(calls === 0) calls = 1
      this.state.servers.map((s, i) => {
        if(curSt[i].state === 1 && curSt[i].cur > 0){
          curSt[i].cur--;
        }else{
          curSt[i].cur = 0;
          curSt[i].time = 0;
          curSt[i].state = 1;
          this.state.queue.map((q, i) => {
            if(curSt[i].state === 1){
              for(var j = 0; j < q.length; ++i){
                if(q[j].was === 0){
                  cnt++
                  W += time - Math.min(q[j].time, 0)
                  curSt[i].state = 0;
                  curSt[i].time = Math.random() * 1800
                  th = th + curSt[i].time
                  curQueue[i].was = 1;
                  break;
                }
              }
            }
          })
        }
      })

      this.setState({
        th: th,
        servers: curSt,
        queue: curQueue,
        avgWaitingTime: W / calls,
        avgTh: th / cnt
      })
    }, 100)
  }

  render() {
    return (
      <div className="App">
        <h1>Call center</h1>
        <h3>Average waiting time: {this.state.avgWaitingTime / 600} sec</h3>
        <h3>Average call arrival rate: {this.state.lyambda / 600} sec</h3>
        <h3>Average number of calls: {(this.state.lyambda * this.state.avgTh) / 360000} calls/sec</h3>
        <h3>Average time a call spends in a system: {this.state.avgTh / 600} sec</h3>
      </div>
    );
  }
}

export default App;
