<?php
    include('config.php');
    $sql = "SELECT * FROM user order by score_history desc";
    $query = $conn->query($sql) or die (mysqli_error($conn));
    while($data = mysqli_fetch_array($query)){
        // echo $data['nama'].";".$data['point_history'].";";
        echo "ID:".$data['id']."&Nama:".$data['username']."&Password:".$data['password']."&Score:".$data['score_history'].";";
    }
?>
