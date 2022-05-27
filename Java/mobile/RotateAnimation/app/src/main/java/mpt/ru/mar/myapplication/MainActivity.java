package mpt.ru.mar.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.ImageView;

public class MainActivity extends AppCompatActivity {

    private Button btnrclock;
    private Button btnrantick;
    private Button btnfIn;
    private Button btnfOut;
    private ImageView img;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        btnrclock = (Button) findViewById(R.id.btnRClk);
        btnrantick = (Button) findViewById(R.id.btnRAClk);
        btnfIn = (Button)findViewById(R.id.btnFadeIn);
        btnfOut = (Button)findViewById(R.id.btnFadeOut);
        img = (ImageView) findViewById(R.id.imgvw);
        btnrclock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Animation aniRotateClk = AnimationUtils.loadAnimation(getApplicationContext(), R.anim.rotate_clockwise);
                img.startAnimation(aniRotateClk);
            }
        });
        btnrantick.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Animation animRotateAclk = AnimationUtils.loadAnimation(getApplicationContext(), R.anim.rotate_anticlockwise);
                img.startAnimation(animRotateAclk);
            }
        });

        btnfIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Animation animFadeIn = AnimationUtils.loadAnimation(getApplicationContext(),R.anim.fade_in);
                img.startAnimation(animFadeIn);
            }
        });
        btnfOut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Animation animFadeOut = AnimationUtils.loadAnimation(getApplicationContext(),R.anim.fade_out);
                img.startAnimation(animFadeOut);
            }
        });
    }
}