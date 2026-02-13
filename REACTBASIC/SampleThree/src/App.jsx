
import './App.css';
import Quiz from './components/quiz';
import GenerateResults from './components/results';
function App() {

  return (
    <>
      <div >
        <div className='app-container card'>Quiz Form Title
        <Quiz />
        <GenerateResults />
        </div>
      
      </div>
    </>
  )
}

export default App
