<?php 
    include("config.php");
    $username = $_REQUEST['username'];
    $score_history = $_REQUEST['score_history'];

    $sql = "UPDATE user SET score_history='$score_history' WHERE username='$username'";
    $sql_check_score = "SELECT score_history FROM user WHERE username='$username'";

    $query = $conn->query($sql_check_score) or die (mysqli_error($conn));
    while($data = mysqli_fetch_array($query)){
        // echo "nilai " . $data['score_history'] . "<br>";
        if($score_history > $data['score_history']){
            mysqli_query($conn, $sql);
            echo "Score Updated";
        } else {
            echo "Update Failed";
        }
    }
    
?>