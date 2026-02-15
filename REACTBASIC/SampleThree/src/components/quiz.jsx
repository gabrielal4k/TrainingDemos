import React, { useState } from "react";
import GenerateResults from './results';

function Quiz(){

    const preAnswers = [null,null,null];
    const [userAnswers, setUserAnswers] = useState(preAnswers);
    const [currentQuestion, setCurrentQuestion] = useState(0);
    const selectedAnswer = userAnswers[currentQuestion];

    const [flagFinished, setFlagFinished] = useState(false);
    const questionaires = [
        {
            question: "What is the capital of France?",
            options: ["Berlin", "London", "Paris", "Rome"],
            answer: "Paris"
        },
        {
            question: "Which language is used for web apps",
            options: [".NET", "PHP", "Javascript", "All"],
            answer: "All"
        },
        {
            question: "What does JSX stand for?",
            options: [
                "Javascript XML",
                "Java Syntax eXtension",
                "Just a Simple eXample",
                "None of the above"
            ],
            answer: "Javascript XML"
        },

    ];

    function selectOptions(option){
        const newUserAnswer = [...userAnswers]
        newUserAnswer[currentQuestion] = option;

        setUserAnswers(newUserAnswer);
    }

    function NextQuestion(){
        if(currentQuestion === questionaires.length - 1)
        {
            setFlagFinished(true);
        }else{
            setCurrentQuestion(currentQuestion + 1);
        }
    }
    
    function PreviousQuestion(){

        if(currentQuestion > 0){
            setCurrentQuestion(currentQuestion - 1);
        }
    }

    function restartQuiz(){
        setUserAnswers(preAnswers);
        setCurrentQuestion(0);
        setFlagFinished(false);
    };


    if(flagFinished){
    return <GenerateResults userAnswers={userAnswers} questionaires={questionaires} restartQuiz={restartQuiz}/>
    }

    return (
    <div className="">
    <h2>Questionaire {currentQuestion + 1}</h2>
        <p className="question">{questionaires[currentQuestion].question}</p>
        
        {questionaires[currentQuestion].options.map((option) =>
        <button key={option} className={"primary-btn option" + (selectedAnswer === option ? " selected-option" : "")} onClick={() => selectOptions(option)}>
            {""}
            {option}
            </button>
        )}

        {/* <p>Selected: {selectedOption}</p> */}

        <div className="card-footer">
            <button onClick={PreviousQuestion} disabled={currentQuestion === 0} className="btn-primary" >
                Previous
            </button>
            <button onClick={NextQuestion} disabled={!selectedAnswer}  className="btn-primary">
                {currentQuestion === questionaires.length - 1? "Finish" : "Next"}
            </button>
        </div>

    </div>
    )
}

export default Quiz;