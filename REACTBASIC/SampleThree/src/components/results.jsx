

function GenerateResults({userAnswers,questionaires,restartQuiz}){

    const score = filterScores();

    function filterScores(){
        let finalScore = 0;
        
        userAnswers.forEach((answer, index) => {
            if(answer === questionaires[index].answer){
                finalScore++;
            }
        });

        return finalScore;
    }

    return (
    <div className="result-footer">
        <div>
            <h3>Done</h3>
        <p>Scored {score} out of {questionaires.length}</p>
            <button className="btn-primary option" onClick={restartQuiz}>Restart</button>
        </div>
    </div>
    )
  
}


export default GenerateResults;