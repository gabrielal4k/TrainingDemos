

function Quiz(){

    const questionaires = [

        {
            question: "What is the capital of France?",
            options: ["Berlin", "London", "Paris", "Rome"],
            answer: "Paris"
        },
        {
            question: "Which language is used for web apps",
            options: [".NET", "PHP", "Javascript", "HTML"],
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

    ]


    return <div className="card">Quiz</div>
}

export default Quiz;